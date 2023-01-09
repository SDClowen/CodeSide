namespace CodeSide.Views
{
	// Token: 0x02000005 RID: 5
	public partial class MainWindow
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000023F8 File Offset: 0x000005F8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002430 File Offset: 0x00000630
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemNew = new System.Windows.Forms.MenuItem();
            this.menuItemOpenFile = new System.Windows.Forms.MenuItem();
            this.menuItemCloseFile = new System.Windows.Forms.MenuItem();
            this.menuItemCloseAll = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItemHistory = new System.Windows.Forms.MenuItem();
            this.openHistoryFile = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemSaveDocument = new System.Windows.Forms.MenuItem();
            this.menuItemPrint = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.editCut = new System.Windows.Forms.MenuItem();
            this.editCopy = new System.Windows.Forms.MenuItem();
            this.editPaste = new System.Windows.Forms.MenuItem();
            this.editSelectAll = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItemCommentSelectedLines = new System.Windows.Forms.MenuItem();
            this.menuItemUncommentSelectedLines = new System.Windows.Forms.MenuItem();
            this.menuItemIncreaseIndent = new System.Windows.Forms.MenuItem();
            this.menuItemDecreaseIndent = new System.Windows.Forms.MenuItem();
            this.menuItemAutoIndentSelected = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.editUndo = new System.Windows.Forms.MenuItem();
            this.editRedo = new System.Windows.Forms.MenuItem();
            this.menuItemExpandRegions = new System.Windows.Forms.MenuItem();
            this.menuItemCollapseRegions = new System.Windows.Forms.MenuItem();
            this.menuItemExpandSelectedBlock = new System.Windows.Forms.MenuItem();
            this.menuItemCollapseSelectedBlock = new System.Windows.Forms.MenuItem();
            this.menuItemEncoding = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemSearchWindow = new System.Windows.Forms.MenuItem();
            this.menuItemReplaceWindow = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItemGoBracketLeft = new System.Windows.Forms.MenuItem();
            this.menuItemGoBracketRight = new System.Windows.Forms.MenuItem();
            this.menuItemLanguage = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItemExportAsRtf = new System.Windows.Forms.MenuItem();
            this.menuItemExportAsHtml = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemThemeLight = new System.Windows.Forms.MenuItem();
            this.menuItemThemeDark = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItemStartStopMacroRecording = new System.Windows.Forms.MenuItem();
            this.menuItemExecuteMacro = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.tabControl = new System.Windows.Forms.Chrome();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelDocumentLang = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuIconizer = new CodeSide.UI.OwnerDrawnMenu(this.components);
            this.encodingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuIconizer)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem10,
            this.menuItemEncoding,
            this.menuItem3,
            this.menuItem5,
            this.menuItemLanguage,
            this.menuItem12,
            this.menuItem6,
            this.menuItem19,
            this.menuItem13});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNew,
            this.menuItemOpenFile,
            this.menuItemCloseFile,
            this.menuItemCloseAll,
            this.menuItem25,
            this.menuItemHistory,
            this.menuItem4,
            this.menuItemSaveDocument,
            this.menuItemPrint,
            this.menuItemExit});
            this.menuItem1.Text = "File";
            // 
            // menuItemNew
            // 
            this.mainMenuIconizer.SetImage(this.menuItemNew, global::CodeSide.Properties.Resources.AddCustomControl);
            this.menuItemNew.Index = 0;
            this.menuItemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.menuItemNew.Text = "New";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // menuItemOpenFile
            // 
            this.mainMenuIconizer.SetImage(this.menuItemOpenFile, global::CodeSide.Properties.Resources.OpenLink);
            this.menuItemOpenFile.Index = 1;
            this.menuItemOpenFile.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpenFile.Text = "Open";
            this.menuItemOpenFile.Click += new System.EventHandler(this.MenuItemOpenFile_Click);
            // 
            // menuItemCloseFile
            // 
            this.mainMenuIconizer.SetImage(this.menuItemCloseFile, global::CodeSide.Properties.Resources.Close);
            this.menuItemCloseFile.Index = 2;
            this.menuItemCloseFile.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.menuItemCloseFile.Text = "Close";
            this.menuItemCloseFile.Click += new System.EventHandler(this.MenuItemCloseFile_Click);
            // 
            // menuItemCloseAll
            // 
            this.mainMenuIconizer.SetImage(this.menuItemCloseAll, global::CodeSide.Properties.Resources.EmptyBucket);
            this.menuItemCloseAll.Index = 3;
            this.menuItemCloseAll.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftQ;
            this.menuItemCloseAll.Text = "Close All";
            this.menuItemCloseAll.Click += new System.EventHandler(this.menuItemCloseAll_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 4;
            this.menuItem25.Text = "-";
            // 
            // menuItemHistory
            // 
            this.menuItemHistory.Index = 5;
            this.menuItemHistory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openHistoryFile,
            this.menuItem24});
            this.menuItemHistory.Text = "History";
            // 
            // openHistoryFile
            // 
            this.openHistoryFile.Index = 0;
            this.openHistoryFile.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftT;
            this.openHistoryFile.Text = "Reopen closed file";
            this.openHistoryFile.Click += new System.EventHandler(this.openHistoryFile_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 1;
            this.menuItem24.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.Text = "-";
            // 
            // menuItemSaveDocument
            // 
            this.mainMenuIconizer.SetImage(this.menuItemSaveDocument, global::CodeSide.Properties.Resources.Save);
            this.menuItemSaveDocument.Index = 7;
            this.menuItemSaveDocument.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSaveDocument.Text = "Save";
            this.menuItemSaveDocument.Click += new System.EventHandler(this.menuItemSaveDocument_Click);
            // 
            // menuItemPrint
            // 
            this.mainMenuIconizer.SetImage(this.menuItemPrint, global::CodeSide.Properties.Resources.Print);
            this.menuItemPrint.Index = 8;
            this.menuItemPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItemPrint.Text = "Print";
            this.menuItemPrint.Click += new System.EventHandler(this.menuItemPrint_Click);
            // 
            // menuItemExit
            // 
            this.mainMenuIconizer.SetImage(this.menuItemExit, global::CodeSide.Properties.Resources.Exit);
            this.menuItemExit.Index = 9;
            this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.editCut,
            this.editCopy,
            this.editPaste,
            this.editSelectAll,
            this.menuItem21});
            this.menuItem2.Text = "Edit";
            // 
            // editCut
            // 
            this.mainMenuIconizer.SetImage(this.editCut, global::CodeSide.Properties.Resources.Cut);
            this.editCut.Index = 0;
            this.editCut.Text = "Cut";
            this.editCut.Click += new System.EventHandler(this.editCut_Click);
            // 
            // editCopy
            // 
            this.mainMenuIconizer.SetImage(this.editCopy, global::CodeSide.Properties.Resources.Copy);
            this.editCopy.Index = 1;
            this.editCopy.Text = "Copy";
            this.editCopy.Click += new System.EventHandler(this.editCopy_Click);
            // 
            // editPaste
            // 
            this.mainMenuIconizer.SetImage(this.editPaste, global::CodeSide.Properties.Resources.Paste);
            this.editPaste.Index = 2;
            this.editPaste.Text = "Paste";
            this.editPaste.Click += new System.EventHandler(this.editPaste_Click);
            // 
            // editSelectAll
            // 
            this.mainMenuIconizer.SetImage(this.editSelectAll, global::CodeSide.Properties.Resources.TextArea);
            this.editSelectAll.Index = 3;
            this.editSelectAll.Text = "Select All";
            this.editSelectAll.Click += new System.EventHandler(this.editSelectAll_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 4;
            this.menuItem21.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCommentSelectedLines,
            this.menuItemUncommentSelectedLines,
            this.menuItemIncreaseIndent,
            this.menuItemDecreaseIndent,
            this.menuItemAutoIndentSelected});
            this.menuItem21.Text = "Selected";
            // 
            // menuItemCommentSelectedLines
            // 
            this.menuItemCommentSelectedLines.Index = 0;
            this.menuItemCommentSelectedLines.Text = "Comment selected lines";
            this.menuItemCommentSelectedLines.Click += new System.EventHandler(this.menuItemCommentSelectedLines_Click);
            // 
            // menuItemUncommentSelectedLines
            // 
            this.menuItemUncommentSelectedLines.Index = 1;
            this.menuItemUncommentSelectedLines.Text = "Uncomment selected lines";
            this.menuItemUncommentSelectedLines.Click += new System.EventHandler(this.menuItemUncommentSelectedLines_Click);
            // 
            // menuItemIncreaseIndent
            // 
            this.menuItemIncreaseIndent.Index = 2;
            this.menuItemIncreaseIndent.Text = "Increase Indent [Tab]";
            this.menuItemIncreaseIndent.Click += new System.EventHandler(this.menuItemIncreaseIndent_Click);
            // 
            // menuItemDecreaseIndent
            // 
            this.menuItemDecreaseIndent.Index = 3;
            this.menuItemDecreaseIndent.Text = "Decrease Indent [Shift + Tab]";
            this.menuItemDecreaseIndent.Click += new System.EventHandler(this.menuItemDecreaseIndent_Click);
            // 
            // menuItemAutoIndentSelected
            // 
            this.menuItemAutoIndentSelected.Index = 4;
            this.menuItemAutoIndentSelected.Text = "Auto Indent";
            this.menuItemAutoIndentSelected.Click += new System.EventHandler(this.menuItemAutoIndentSelected_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.editUndo,
            this.editRedo,
            this.menuItemExpandRegions,
            this.menuItemCollapseRegions,
            this.menuItemExpandSelectedBlock,
            this.menuItemCollapseSelectedBlock});
            this.menuItem10.Text = "Navigation";
            // 
            // editUndo
            // 
            this.editUndo.Index = 0;
            this.editUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.editUndo.Text = "Undo";
            this.editUndo.Click += new System.EventHandler(this.editUndo_Click);
            // 
            // editRedo
            // 
            this.editRedo.Index = 1;
            this.editRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.editRedo.Text = "Redo";
            this.editRedo.Click += new System.EventHandler(this.editRedo_Click);
            // 
            // menuItemExpandRegions
            // 
            this.menuItemExpandRegions.Index = 2;
            this.menuItemExpandRegions.Text = "Expand Regions";
            this.menuItemExpandRegions.Click += new System.EventHandler(this.menuItemExpandRegions_Click);
            // 
            // menuItemCollapseRegions
            // 
            this.menuItemCollapseRegions.Index = 3;
            this.menuItemCollapseRegions.Text = "Collapse Regions";
            this.menuItemCollapseRegions.Click += new System.EventHandler(this.menuItemCollapseRegions_Click);
            // 
            // menuItemExpandSelectedBlock
            // 
            this.menuItemExpandSelectedBlock.Index = 4;
            this.menuItemExpandSelectedBlock.Text = "Expand Block";
            this.menuItemExpandSelectedBlock.Click += new System.EventHandler(this.menuItemExpandSelectedBlock_Click);
            // 
            // menuItemCollapseSelectedBlock
            // 
            this.menuItemCollapseSelectedBlock.Index = 5;
            this.menuItemCollapseSelectedBlock.Text = "Collapse Block";
            this.menuItemCollapseSelectedBlock.Click += new System.EventHandler(this.menuItemCollapseSelectedBlock_Click);
            // 
            // menuItemEncoding
            // 
            this.menuItemEncoding.Index = 3;
            this.menuItemEncoding.Text = "Encoding";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11});
            this.menuItem3.Text = "View";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "Side Bar";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSearchWindow,
            this.menuItemReplaceWindow,
            this.menuItem20});
            this.menuItem5.Text = "Go";
            // 
            // menuItemSearchWindow
            // 
            this.mainMenuIconizer.SetImage(this.menuItemSearchWindow, global::CodeSide.Properties.Resources.SearchContract);
            this.menuItemSearchWindow.Index = 0;
            this.menuItemSearchWindow.Text = "Search";
            this.menuItemSearchWindow.Click += new System.EventHandler(this.menuItemSearchWindow_Click);
            // 
            // menuItemReplaceWindow
            // 
            this.mainMenuIconizer.SetImage(this.menuItemReplaceWindow, global::CodeSide.Properties.Resources.ReplaceAll);
            this.menuItemReplaceWindow.Index = 1;
            this.menuItemReplaceWindow.Text = "Replace";
            this.menuItemReplaceWindow.Click += new System.EventHandler(this.menuItemReplaceWindow_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGoBracketLeft,
            this.menuItemGoBracketRight});
            this.menuItem20.Text = "Bracket";
            // 
            // menuItemGoBracketLeft
            // 
            this.menuItemGoBracketLeft.Index = 0;
            this.menuItemGoBracketLeft.Text = "Left";
            this.menuItemGoBracketLeft.Click += new System.EventHandler(this.menuItemGoBracketLeft_Click);
            // 
            // menuItemGoBracketRight
            // 
            this.menuItemGoBracketRight.Index = 1;
            this.menuItemGoBracketRight.Text = "Right";
            this.menuItemGoBracketRight.Click += new System.EventHandler(this.menuItemGoBracketRight_Click);
            // 
            // menuItemLanguage
            // 
            this.menuItemLanguage.Index = 6;
            this.menuItemLanguage.Text = "Language";
            this.menuItemLanguage.Popup += new System.EventHandler(this.menuItemLanguage_Popup);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 7;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem22});
            this.menuItem12.Text = "Tools";
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 0;
            this.menuItem22.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExportAsRtf,
            this.menuItemExportAsHtml});
            this.menuItem22.Text = "Export";
            // 
            // menuItemExportAsRtf
            // 
            this.menuItemExportAsRtf.Index = 0;
            this.menuItemExportAsRtf.Text = "as RTF";
            this.menuItemExportAsRtf.Click += new System.EventHandler(this.menuItemExportAsRtf_Click);
            // 
            // menuItemExportAsHtml
            // 
            this.menuItemExportAsHtml.Index = 1;
            this.menuItemExportAsHtml.Text = "as HTML";
            this.menuItemExportAsHtml.Click += new System.EventHandler(this.menuItemExportAsHtml_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 8;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemThemeLight,
            this.menuItemThemeDark});
            this.menuItem6.Text = "Theme";
            // 
            // menuItemThemeLight
            // 
            this.menuItemThemeLight.Index = 0;
            this.menuItemThemeLight.Text = "Light";
            this.menuItemThemeLight.Click += new System.EventHandler(this.OnClick_MenuItemTheme);
            // 
            // menuItemThemeDark
            // 
            this.menuItemThemeDark.Index = 1;
            this.menuItemThemeDark.MergeOrder = 1;
            this.menuItemThemeDark.Text = "Dark";
            this.menuItemThemeDark.Click += new System.EventHandler(this.OnClick_MenuItemTheme);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 9;
            this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemStartStopMacroRecording,
            this.menuItemExecuteMacro});
            this.menuItem19.Text = "Macro";
            // 
            // menuItemStartStopMacroRecording
            // 
            this.menuItemStartStopMacroRecording.Index = 0;
            this.menuItemStartStopMacroRecording.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.menuItemStartStopMacroRecording.Text = "Start / Stop Recording";
            this.menuItemStartStopMacroRecording.Click += new System.EventHandler(this.menuItemStartStopMacroRecording_Click);
            // 
            // menuItemExecuteMacro
            // 
            this.menuItemExecuteMacro.Index = 1;
            this.menuItemExecuteMacro.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.menuItemExecuteMacro.Text = "Execute Macro";
            this.menuItemExecuteMacro.Click += new System.EventHandler(this.menuItemExecuteMacro_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 10;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem15});
            this.menuItem13.Text = "Help";
            // 
            // menuItem14
            // 
            this.mainMenuIconizer.SetImage(this.menuItem14, global::CodeSide.Properties.Resources.AboutBox);
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "About";
            // 
            // menuItem15
            // 
            this.mainMenuIconizer.SetImage(this.menuItem15, global::CodeSide.Properties.Resources.RefreshPhoneUI);
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "Check Updates";
            // 
            // tabControl
            // 
            this.tabControl.DisplayStyle = System.Windows.Forms.TabStyle.Chrome;
            // 
            // 
            // 
            this.tabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.tabControl.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.White;
            this.tabControl.DisplayStyleProvider.FocusTrack = false;
            this.tabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControl.DisplayStyleProvider.Opacity = 1F;
            this.tabControl.DisplayStyleProvider.Overlap = 16;
            this.tabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(7, 5);
            this.tabControl.DisplayStyleProvider.Radius = 16;
            this.tabControl.DisplayStyleProvider.ShowTabCloser = true;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl.ItemSize = new System.Drawing.Size(180, 24);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1001, 516);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlRemoved);
            this.tabControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDragDrop);
            this.tabControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDragEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelDocumentLang,
            this.labelInfo,
            this.encodingLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1001, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelDocumentLang
            // 
            this.labelDocumentLang.ForeColor = System.Drawing.Color.White;
            this.labelDocumentLang.Name = "labelDocumentLang";
            this.labelDocumentLang.Size = new System.Drawing.Size(105, 19);
            this.labelDocumentLang.Text = "<DocumentLang>";
            // 
            // labelInfo
            // 
            this.labelInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(777, 19);
            this.labelInfo.Spring = true;
            this.labelInfo.Text = "<info>";
            // 
            // mainMenuIconizer
            // 
            this.mainMenuIconizer.ContainerControl = this;
            // 
            // encodingLabel
            // 
            this.encodingLabel.ForeColor = System.Drawing.Color.White;
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(73, 19);
            this.encodingLabel.Text = "<encoding>";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1001, 540);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeSide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDragEnter);
            this.DoubleClick += new System.EventHandler(this.CodeSide_DoubleClick);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuIconizer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000005 RID: 5
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.MainMenu mainMenu;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.MenuItem menuItem1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.MenuItem menuItemOpenFile;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.MenuItem menuItemCloseFile;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.MenuItem menuItem4;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.MenuItem menuItemExit;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.MenuItem menuItem2;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.MenuItem editUndo;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.MenuItem editRedo;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.MenuItem menuItem3;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.MenuItem menuItem11;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.MenuItem menuItem5;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.MenuItem menuItem12;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.MenuItem menuItemEncoding;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.MenuItem menuItem13;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.MenuItem menuItem14;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.MenuItem menuItem15;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.MenuItem menuItemLanguage;
        private System.Windows.Forms.MenuItem menuItemExpandRegions;
        private System.Windows.Forms.MenuItem menuItemCollapseRegions;
        private System.Windows.Forms.MenuItem menuItemSearchWindow;
        private System.Windows.Forms.MenuItem menuItemReplaceWindow;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItemCollapseSelectedBlock;
        private System.Windows.Forms.MenuItem menuItemExpandSelectedBlock;
        private System.Windows.Forms.MenuItem menuItemIncreaseIndent;
        private System.Windows.Forms.MenuItem menuItemDecreaseIndent;
        private System.Windows.Forms.MenuItem menuItemCommentSelectedLines;
        private System.Windows.Forms.MenuItem menuItemUncommentSelectedLines;
        private System.Windows.Forms.MenuItem menuItemAutoIndentSelected;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItemGoBracketLeft;
        private System.Windows.Forms.MenuItem menuItemGoBracketRight;
        private System.Windows.Forms.MenuItem menuItemPrint;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItemStartStopMacroRecording;
        private System.Windows.Forms.MenuItem menuItemExecuteMacro;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem menuItemExportAsRtf;
        private System.Windows.Forms.MenuItem menuItemExportAsHtml;
        private System.Windows.Forms.MenuItem menuItemSaveDocument;
        private System.Windows.Forms.Chrome tabControl;
        private System.Windows.Forms.MenuItem menuItemNew;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem openHistoryFile;
        private System.Windows.Forms.MenuItem menuItem24;
        public System.Windows.Forms.MenuItem menuItemHistory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelDocumentLang;
        private System.Windows.Forms.ToolStripStatusLabel labelInfo;
        private System.Windows.Forms.MenuItem menuItemCloseAll;
        private System.Windows.Forms.MenuItem editCut;
        private System.Windows.Forms.MenuItem editCopy;
        private System.Windows.Forms.MenuItem editPaste;
        private System.Windows.Forms.MenuItem editSelectAll;
        private System.Windows.Forms.MenuItem menuItem10;
        private UI.OwnerDrawnMenu mainMenuIconizer;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItemThemeLight;
        private System.Windows.Forms.MenuItem menuItemThemeDark;
        private System.Windows.Forms.ToolStripStatusLabel encodingLabel;
    }
}
