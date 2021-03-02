namespace CodeSide.Views.Controls
{
    partial class DocumentControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentControl));
            this.Editor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.editorContextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemPaste = new System.Windows.Forms.MenuItem();
            this.SelectAll = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Editor)).BeginInit();
            this.SuspendLayout();
            // 
            // Editor
            // 
            this.Editor.AllowSeveralTextStyleDrawing = true;
            this.Editor.AutoCompleteBrackets = true;
            this.Editor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.Editor.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);^\\s*(case|default)\\s*[^:]*(?" +
    "<range>:)\\s*(?<range>[^;]+);";
            this.Editor.AutoScrollMinSize = new System.Drawing.Size(47, 19);
            this.Editor.BackBrush = null;
            this.Editor.BookmarkColor = System.Drawing.Color.LightCoral;
            this.Editor.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.Editor.CharHeight = 19;
            this.Editor.CharWidth = 8;
            this.Editor.CurrentLineColor = System.Drawing.Color.DarkGray;
            this.Editor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Editor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.Editor.Hotkeys = resources.GetString("Editor.Hotkeys");
            this.Editor.IndentBackColor = System.Drawing.Color.Transparent;
            this.Editor.IsReplaceMode = false;
            this.Editor.Language = FastColoredTextBoxNS.Language.CSharp;
            this.Editor.LeftBracket = '(';
            this.Editor.LeftBracket2 = '{';
            this.Editor.LeftPadding = 20;
            this.Editor.LineInterval = 2;
            this.Editor.LineNumberColor = System.Drawing.Color.DimGray;
            this.Editor.Location = new System.Drawing.Point(0, 0);
            this.Editor.Name = "Editor";
            this.Editor.Paddings = new System.Windows.Forms.Padding(0);
            this.Editor.RightBracket = ')';
            this.Editor.RightBracket2 = '}';
            this.Editor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Editor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("Editor.ServiceColors")));
            this.Editor.ServiceLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Editor.ShowCaretWhenInactive = true;
            this.Editor.ShowFoldingLines = true;
            this.Editor.Size = new System.Drawing.Size(700, 494);
            this.Editor.TabIndex = 0;
            this.Editor.TextAreaBorderColor = System.Drawing.Color.Transparent;
            this.Editor.Zoom = 100;
            this.Editor.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.Editor_TextChangedDelayed);
            this.Editor.SelectionChangedDelayed += new System.EventHandler(this.Editor_SelectionChangedDelayed);
            this.Editor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Editor_DragDrop);
            this.Editor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Editor_DragEnter);
            // 
            // editorContextMenu
            // 
            this.editorContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.SelectAll});
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 0;
            this.menuItemCut.Text = "Cut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 1;
            this.menuItemCopy.Text = "Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Index = 2;
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Index = 3;
            this.SelectAll.Text = "Select All";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Editor);
            this.DoubleBuffered = true;
            this.Name = "DocumentControl";
            this.Size = new System.Drawing.Size(700, 494);
            ((System.ComponentModel.ISupportInitialize)(this.Editor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox Editor;
        private System.Windows.Forms.ContextMenu editorContextMenu;
        private System.Windows.Forms.MenuItem menuItemCut;
        private System.Windows.Forms.MenuItem menuItemCopy;
        private System.Windows.Forms.MenuItem menuItemPaste;
        private System.Windows.Forms.MenuItem SelectAll;
    }
}
