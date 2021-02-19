using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using FastColoredTextBoxNS;

namespace CodeSide.Views.Controls
{
    public partial class DocumentControl : UserControl
    {
        public string FilePath;
        public string FileName;

        public bool ShowInvisibleChars = false;

        private Style sameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Gray)));
        private Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.Gray);
        private DateTime lastNavigatedDateTime;

        public DocumentControl()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Editor.AddStyle(sameWordsStyle);
            ContextMenu = editorContextMenu;
        }

        public void SaveFile(bool showDialog = false)
        {
            if (!Editor.IsChanged)
                return;

            if (showDialog && MessageBox.Show(this, $"You have not saved the {FileName}. Do you want to save the file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            while (string.IsNullOrWhiteSpace(FilePath))
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = FileName;

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                FilePath = saveFileDialog.FileName;
            }

            Editor.SaveToFile(FilePath, Encoding.UTF8);
        }

        public void Destroy()
        {
            SaveFile(true);
        }

        public async void LoadFileAsync(string file)
        {
            await Task.Run(() => { Editor.OpenFile(file); });
        }

        private void Editor_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            var range = e.ChangedRange;

            range.ClearStyle(invisibleCharsStyle);
            if (ShowInvisibleChars)
                range.SetStyle(invisibleCharsStyle, @".$|.\r\n|\s");
        }

        public class InvisibleCharsRenderer : Style
        {
            Pen pen;

            public InvisibleCharsRenderer(Pen pen)
            {
                this.pen = pen;
            }

            public override void Draw(Graphics gr, Point position, Range range)
            {
                var tb = range.tb;
                using (Brush brush = new SolidBrush(pen.Color))
                    foreach (var place in range)
                    {
                        switch (tb[place].c)
                        {
                            case ' ':
                                var point = tb.PlaceToPoint(place);
                                point.Offset(tb.CharWidth / 2, tb.CharHeight / 2);
                                gr.DrawLine(pen, point.X, point.Y, point.X + 1, point.Y);
                                break;
                        }

                        if (tb[place.iLine].Count - 1 == place.iChar)
                        {
                            var point = tb.PlaceToPoint(place);
                            point.Offset(tb.CharWidth, 0);
                            gr.DrawString("¶", tb.Font, brush, point);
                        }
                    }
            }
        }

        private void Editor_SelectionChangedDelayed(object sender, EventArgs e)
        {
            var tb = Editor;
            //remember last visit time
            if (tb.Selection.IsEmpty && tb.Selection.Start.iLine < tb.LinesCount)
            {
                if (lastNavigatedDateTime != tb[tb.Selection.Start.iLine].LastVisit)
                {
                    tb[tb.Selection.Start.iLine].LastVisit = DateTime.Now;
                    lastNavigatedDateTime = tb[tb.Selection.Start.iLine].LastVisit;
                }
            }

            //highlight same words
            tb.VisibleRange.ClearStyle(sameWordsStyle);
            if (!tb.Selection.IsEmpty)
                return;//user selected diapason
            //get fragment around caret
            var fragment = tb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            Range[] ranges = tb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();

            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(sameWordsStyle);
        }

        private void Editor_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files?.Length != 0)
                Globals.MainWindow.CommonDragDrop(sender, e);
        }

        private void Editor_DragEnter(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(files?.Length != 0)
                e.Effect = DragDropEffects.Copy;
        }

        internal void ExportAsHtml()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "HTML with <PRE> tag|*.html|HTML without <PRE> tag|*.html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string html = "";

                if (sfd.FilterIndex == 1)
                {
                    html = Editor.Html;
                }
                if (sfd.FilterIndex == 2)
                {

                    ExportToHTML exporter = new ExportToHTML();
                    exporter.UseBr = true;
                    exporter.UseNbsp = false;
                    exporter.UseForwardNbsp = true;
                    exporter.UseStyleTag = true;
                    html = exporter.GetHtml(Editor);
                }
                File.WriteAllText(sfd.FileName, html);
            }
        }

        internal void ExportAsRtf()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "RTF|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, Editor.Rtf);
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            Editor.Cut();
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            Editor.Copy();
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            Editor.Paste();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            Editor.SelectAll();
        }
    }
}
