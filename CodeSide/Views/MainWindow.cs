using CodeSide.Extensions;
using CodeSide.Models;
using CodeSide.Native;
using CodeSide.UI;
using CodeSide.UI.Helpers;
using CodeSide.Views.Controls;
using FastColoredTextBoxNS;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CodeSide.Views
{
    public partial class MainWindow : CodeSide.UI.Controls.Form
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private int _tabCounter = 0;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private string[] startingArgs;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DocumentControl ActiveDocument
        {
            get {
                if (tabControl.SelectedIndex == -1)
                    return null;

                if (tabControl.SelectedTab?.Controls.Count == 0)
                    return null;

                return tabControl.SelectedTab?.Controls[0] as DocumentControl;
            }
        }

        private MenuItem[] _cachedEncodingMenuItems;

        public MainWindow(string[] args)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            WindowsHelper.UserPreferenceChangedEvent = new Action(UserPreferenceChangedEvent);
            this.startingArgs = args;

            var alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            menuItemEncoding.MenuItems.AddRange(alphabets.Select(p => new MenuItem(p.ToString())).ToArray());

            _cachedEncodingMenuItems = Encoding.GetEncodings().OrderBy(p => p.DisplayName).Select(p =>
            {
                return new MenuItem($"{p.DisplayName}   ({p.Name})", OnEncodingMenuItemClick)
                {
                    Tag = p
                };
            }).ToArray();
            foreach (var item in _cachedEncodingMenuItems)
            {
                for (var i = 0; i < alphabets.Length; i++)
                    if (char.ToLowerInvariant(alphabets[i]) == char.ToLowerInvariant(item.Text[0]))
                    {
                        menuItemEncoding.MenuItems[i].MenuItems.Add(item);
                        break;
                    }    
            }
            
        }

        private void OnEncodingMenuItemClick(object sender, EventArgs e)
        {
            if (ActiveDocument == null)
                return;

            var current = sender as MenuItem;
            foreach (var item in _cachedEncodingMenuItems)
            {
                item.Checked = false;
                current.Checked = true;
                ActiveDocument.Editor.Encoding = (item.Tag as EncodingInfo).GetEncoding();
                ActiveDocument.Editor.IsChanged = true;
            }
        }

        /// <summary>
        /// NOT WORK!!!!
        /// </summary>
        private void UserPreferenceChangedEvent()
        {
            OnBackColorChanged(new EventArgs());
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_COPYDATA)
            {
                var str = MessagePasser.ReceiveString(m);
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var splited = str.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if(splited.Length != 0)
                        OpenDocumentsFast(splited);
                }
            }

            base.WndProc(ref m);
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        void UpdateLanguageOnMenuItem()
        {
            if (ActiveDocument == null)
                return;

            foreach (MenuItem item in menuItemLanguage.MenuItems)
                item.Checked = item.Text == ActiveDocument.Editor.Language.ToString();
        }

        public bool HasFileOpened(string file)
        {
            object current;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                current = tabControl.TabPages[i].Tag;
                if (current == null)
                    continue;

                if (current.ToString().Equals(file, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        private bool TryParseDocumentLanguage(string file, out Language language)
        {
            language = Language.Custom;

            var extension = Path.GetExtension(file).Remove(0, 1);
            if (string.IsNullOrEmpty(extension))
                return false;

            switch (extension)
            {
                case "cs":
                case "vala":
                case "java":
                    language = Language.CSharp;
                    break;

                case "vb":
                    language = Language.VB;
                    break;

                case "php":
                    language = Language.PHP;
                    break;

                case "js":
                    language = Language.JS;
                    break;

                case "html":
                case "htm":
                    language = Language.HTML;
                    break;

                case "json":
                    language = Language.JSON;
                    break;

                case "lua":
                    language = Language.Lua;
                    break;
                
                case "sql":
                    language = Language.SQL;
                    break;

                case "xml":
                    language = Language.XML;
                    break;

                case "asm":
                    language = Language.AVRASM;
                    break;

                default:
                    return false;
            }

            return true;
        }

        private void OpenDocumentsFast(string[] files)
        {
            if (files.Length == 0)
                return;

            tabControl.Enabled = false;
            tabControl.Visible = false;

            labelInfo.Text = "Please wait...";
            var s = Stopwatch.StartNew();

            tabControl.ControlRemoved-= tabControl_ControlRemoved;
            tabControl.SelectedIndexChanged -= tabControl_SelectedIndexChanged;

            for (int i = 0; i < files.Length; i++)
            {
                if (!TryOpenDocumentFast(files[i], out var tab))
                  continue;

                tabControl.TabPages.Add(tab);
            }

            tabControl.ControlRemoved += tabControl_ControlRemoved;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            tabControl.Enabled = true;
            tabControl.Visible = true;

            labelInfo.Text = $"{files.Length} files loaded in: {s.ElapsedMilliseconds} ms";
        }

        private bool TryOpenDocumentFast(string file, out TabPage tab)
        {
            tab = null;

            if (string.IsNullOrEmpty(file))
                return false;

            if (HasFileOpened(file))
                return false;

            if (!File.Exists(file))
                return false;

            var fileName = Path.GetFileName(file);
            tab = new TabPage(fileName);

            var document = new DocumentControl();
            TryParseDocumentLanguage(file, out var language);
            document.Editor.Language = language;
            document.FileName = fileName;
            document.FilePath = file;

            //Task.Run(() => {
            /*using (var stream = new StreamReader(fileName, true))
            {
                var text = new StringBuilder(1024);
                while (!stream.EndOfStream)
                    text.Append(await stream.ReadToEndAsync());
                document.Editor.Text = text.ToString();
            }*/

            document.LoadFileAsync(file);

            //});

            Globals.Settings.AddHistory(new DocumentHistoryItem
            {
                ActiveOnTab = true,
                FilePath = file
            });

            document.Dock = DockStyle.Fill;
            tab.Tag = file;
            tab.Controls.Add(document);

            return true;
        }

        private async void OpenDocument(string file = null, bool addToHistory = true)
        {
            var document = new DocumentControl();

            if (tabControl.Controls.Count == 0)
                _tabCounter = 0;

            if (!string.IsNullOrEmpty(file))
            {
                if (HasFileOpened(file))
                    return;

                if (!File.Exists(file))
                    return;

                TryParseDocumentLanguage(file, out var language);
                document.Editor.Language = language;

                document.FileName = Path.GetFileName(file);
                document.FilePath = file;

                //Task.Run(() => {
                    var test = Stopwatch.StartNew();
                
                /*using (var stream = new StreamReader(fileName, true))
                {
                    var text = new StringBuilder(1024);
                    while (!stream.EndOfStream)
                        text.Append(await stream.ReadToEndAsync());
                    document.Editor.Text = text.ToString();
                }*/

                document.Editor.OpenFile(file);
                    labelInfo.Text = string.Format("CodeSide - {0} - Loaded: {1} ms", file, test.ElapsedMilliseconds);
                //});

                if(addToHistory)
                {
                    Globals.Settings.AddHistory(new DocumentHistoryItem
                    {
                        ActiveOnTab = true,
                        FilePath = file
                    });
                }
            }
            else
                document.FileName = "New Document #" + (++_tabCounter);

            document.Dock = DockStyle.Fill;

            //ActiveDocument.BringToFront();

            var tab = new TabPage(Path.GetFileName(document.FileName));
            tab.Tag = file;
            tab.Controls.Add(document);
            tabControl.Controls.Add(tab);
            labelDocumentLang.Text = document.Editor.Language.ToString();

            await Task.Yield();
        }

        private void MenuItemCloseFile_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                var lastIndex = tabControl.SelectedIndex - 1;
                if (lastIndex < 0)
                    lastIndex = 0;

                tabControl.TabPages.Remove(tabControl.SelectedTab);

                // Add settings "Use ordering while closing active tab"
                if (tabControl.TabPages.Count != 1 && Globals.Settings.UseOrderingWhileTabClosing)
                    tabControl.SelectedIndex = lastIndex;
            }
        }

        private void MenuItemOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = string.Join("|", DialogFilters.Filters);
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
                OpenDocumentsFast(dialog.FileNames);
        }

        private void menuItemLanguage_Popup(object sender, EventArgs e)
        {
            UpdateLanguageOnMenuItem();
        }

        private void OnLanguageChangeClickCallBack(object sender, EventArgs e)
        {
            var menuItemLanguage = (sender as MenuItem);
            var language = (Language)Enum.Parse(typeof(Language), menuItemLanguage.Text);

            ActiveDocument.Editor.ClearStylesBuffer();
            ActiveDocument.Editor.Range.ClearStyle(StyleIndex.All);
            ActiveDocument.Editor.Language = language;

            ActiveDocument.Editor.OnTextChanged();

            UpdateLanguageOnMenuItem();
        }

        private void menuItemSearchWindow_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.ShowFindDialog();
        }

        private void menuItemReplaceWindow_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.ShowReplaceDialog();
        }

        private void menuItemExpandSelectedBlock_Click(object sender, EventArgs e)
        {
            var fctb = ActiveDocument.Editor;
            fctb.ExpandBlock(fctb.Selection.Start.iLine, fctb.Selection.End.iLine);
        }

        private void menuItemCollapseSelectedBlock_Click(object sender, EventArgs e)
        {
            var fctb = ActiveDocument.Editor;
            fctb.CollapseBlock(fctb.Selection.Start.iLine, fctb.Selection.End.iLine);
        }

        private void menuItemExpandRegions_Click(object sender, EventArgs e)
        {
            var fctb = ActiveDocument.Editor;
            if (fctb.Language != Language.CSharp)
                return;

            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
            {
                if (fctb[iLine].FoldingStartMarker == @"#region\b")//marker @"#region\b" was used in SetFoldingMarkers()
                    fctb.CollapseFoldingBlock(iLine);
            }
        }

        private void menuItemCollapseRegions_Click(object sender, EventArgs e)
        {
            var fctb = ActiveDocument.Editor;
            if (fctb.Language != Language.CSharp)
                return;

            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
            {
                if (fctb[iLine].FoldingStartMarker == @"#region\b")//marker @"#region\b" was used in SetFoldingMarkers()
                    fctb.ExpandFoldedBlock(iLine);
            }
        }

        private void menuItemIncreaseIndent_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.IncreaseIndent();
        }

        private void menuItemDecreaseIndent_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.DecreaseIndent();
        }

        private void menuItemCommentSelectedLines_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.InsertLinePrefix(ActiveDocument.Editor.CommentPrefix);
        }

        private void menuItemUncommentSelectedLines_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.RemoveLinePrefix(ActiveDocument.Editor.CommentPrefix);
        }

        private void menuItemAutoIndentSelected_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.DoAutoIndent();
        }

        private void menuItemGoBracketLeft_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.GoLeftBracket('{', '}');
        }

        private void menuItemGoBracketRight_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.GoRightBracket('{', '}');
        }

        private void menuItemPrint_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });
        }

        private void menuItemStartStopMacroRecording_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.MacrosManager.IsRecording = !ActiveDocument.Editor.MacrosManager.IsRecording;
        }

        private void menuItemExecuteMacro_Click(object sender, EventArgs e)
        {
            ActiveDocument.Editor.MacrosManager.ExecuteMacros();
        }

        private void menuItemExportAsRtf_Click(object sender, EventArgs e)
        {
            ActiveDocument.ExportAsRtf();
        }

        private void menuItemExportAsHtml_Click(object sender, EventArgs e)
        {
            ActiveDocument.ExportAsHtml();
        }

        private void tabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            tabControl_TabClosing(sender, new TabControlCancelEventArgs((TabPage)e.Control, 0, false, TabControlAction.Deselecting));
        }

        private void tabControl_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            ActiveDocument.Destroy();

            if (tabControl.Controls.Count == 0)
                OpenDocument();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var text = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            if (ActiveDocument == null)
            {
                Text = text;
                return;
            }

            ActiveDocument.Focus();

            var codePage = ActiveDocument.Editor.Encoding.CodePage;
            var encodingMenu = _cachedEncodingMenuItems.FirstOrDefault(p => (p.Tag as EncodingInfo).CodePage == codePage);
            if (encodingMenu != null)
                encodingMenu.Checked = true;

            if (Globals.Settings.ShowFileNameInfoOnTitle)
            {
                if (Globals.Settings.ShowFileNameOnTitleInsteadOfPath)
                    Text = $"{text} - {Path.GetFileName(ActiveDocument.FilePath)}";
                else
                    Text = $"{text} - {ActiveDocument.FilePath}";
            }
        }

        private void CodeSide_DoubleClick(object sender, EventArgs e)
        {
            OpenDocument();
        }

        public void CommonDragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (files == null || files.Length == 0)
                return;

            OpenDocumentsFast(files);
        }

        private void CommonDragEnter(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length != 0)
                e.Effect = DragDropEffects.Copy;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var n = Globals.Settings.History.GetEnumerator();
            while (n.MoveNext())
            {
                if (!HasFileOpened(n.Current.FilePath))
                    n.Current.ActiveOnTab = false;
            }

            foreach (TabPage item in tabControl.TabPages)
            {
                if (item.Controls.Count == 0)
                    continue;

                var document = item.Controls[0] as DocumentControl;
                document.Destroy();

                if(document.Editor.IsChanged && !string.IsNullOrWhiteSpace(document.FilePath))
                    Globals.Settings.AddHistory(new DocumentHistoryItem { 
                        ActiveOnTab = true,
                        FilePath = document.FilePath
                    });
            }

            Globals.Settings.Save();
        }

        private void menuItemSaveDocument_Click(object sender, EventArgs e)
        {
            if (ActiveDocument == null)
                return;

            ActiveDocument.SaveFile();
        }

        private void openHistoryFile_Click(object sender, EventArgs e)
        {
            DocumentHistoryItem current;
            while (Globals.Settings.History.Count != 0 && (current = Globals.Settings.History.Pop()) != null)
            {
                if (!File.Exists(current.FilePath))
                    continue;

                OpenDocument(current.FilePath);
                break;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            menuItemLanguage.MenuItems.AddRange(Enum.GetNames(typeof(Language)).Select(x => new MenuItem(x, OnLanguageChangeClickCallBack)).ToArray());

            if (menuItemLanguage.MenuItems.Count > 0)
                menuItemLanguage.MenuItems[0].Checked = true;

            // TODO: Load settings
            if (!Settings.TryLoad(out Globals.Settings))
            {
                MessageBox.Show("Settings are could not loaded!");
                Environment.Exit(0);
                return;
            }

            DocumentHistoryItem current;
            while (Globals.Settings.History.Count != 0 && (current = Globals.Settings.History.Pop()) != null)
            {
                if (!File.Exists(current.FilePath))
                    continue;

                menuItemHistory.MenuItems.Add(current.ToString(), (d, s) => {
                    OpenDocument(current.FilePath);
                });

                if (!current.ActiveOnTab)
                    continue;

                OpenDocument(current.FilePath, false);
            }

            OpenDocumentsFast(startingArgs);

            if (tabControl.TabPages.Count == 0)
                OpenDocument();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            var count = tabControl.TabPages.Count;
            if (count == 0)
                return;

            tabControl.Enabled = false;
            tabControl.Visible = false;

            labelInfo.Text = "Please wait...";
            var s = Stopwatch.StartNew();

            tabControl.ControlRemoved -= tabControl_ControlRemoved;
            tabControl.SelectedIndexChanged -= tabControl_SelectedIndexChanged;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                tabControl.TabPages[i].Controls[0].Controls.RemoveAt(0);
                tabControl.TabPages[i].Controls.RemoveAt(0);
                GC.SuppressFinalize(tabControl.TabPages[i]);
            }

            tabControl.TabPages.Clear();

            tabControl.ControlRemoved += tabControl_ControlRemoved;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            tabControl.Enabled = true;
            tabControl.Visible = true;

            labelInfo.Text = $"{count} tab pages removed in: {s.ElapsedMilliseconds} ms";
            OpenDocument();

            GC.SuppressFinalize(tabControl.TabPages);
            GC.Collect();
        }

        private void editUndo_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.Undo();
        }

        private void editRedo_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.Redo();
        }

        private void editCut_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.Cut();
        }

        private void editCopy_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.Copy();
        }

        private void editPaste_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.Paste();
        }

        private void editSelectAll_Click(object sender, EventArgs e)
        {
            ActiveDocument?.Editor.SelectAll();
        }

        private void OnClick_MenuItemTheme(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            ColorScheme.Theme = (ColorScheme.THEME)menuItem.MergeOrder;
            BackColor = ColorScheme.BackColor;
            ForeColor = ColorScheme.ForeColor;
            Invalidate();

            if(ActiveDocument == null)
                return;

            ActiveDocument.RefreshTheme();
        }
    }
}
