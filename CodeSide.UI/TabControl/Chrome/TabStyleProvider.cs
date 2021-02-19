using CodeSide.UI;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    [System.ComponentModel.ToolboxItem(false)]
    public abstract class TabStyleProvider : Component
    {
        #region Constructor

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _CloserColor = Color.DarkGray;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _CloserColorActive = Color.Black;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Color _FocusColor = Color.Empty;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected bool _FocusTrack;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected ContentAlignment _ImageAlign;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected float _Opacity = 1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int _Overlap;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Point _Padding;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int _Radius = 1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected bool _ShowTabCloser;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected TabStyle _Style = TabStyle.Angled;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected Chrome _TabControl;

        protected TabStyleProvider(Chrome tabControl)
        {
            this._TabControl = tabControl;
            this._FocusColor = Color.Orange;

            if (this._TabControl.RightToLeftLayout)
            {
                this._ImageAlign = ContentAlignment.MiddleRight;
            }
            else
            {
                this._ImageAlign = ContentAlignment.MiddleLeft;
            }

            //	Must set after the _Overlap as this is used in the calculations of the actual padding
            this.Padding = new Point(6, 3);
        }

        #endregion Constructor

        #region Factory Methods

        [Category("Appearance"), DefaultValue(typeof(Color), "DarkGrey")]
        public Color CloserColor
        {
            get { return this._CloserColor; }
            set
            {
                this._CloserColor = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color CloserColorActive
        {
            get { return this._CloserColorActive; }
            set
            {
                this._CloserColorActive = value;
                this._TabControl.Invalidate();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabStyle DisplayStyle
        {
            get { return this._Style; }
            set { this._Style = value; }
        }

        [Category("Appearance"), DefaultValue(typeof(Color), "Orange")]
        public Color FocusColor
        {
            get { return this._FocusColor; }
            set
            {
                this._FocusColor = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public bool FocusTrack
        {
            get { return this._FocusTrack; }
            set
            {
                this._FocusTrack = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public ContentAlignment ImageAlign
        {
            get { return this._ImageAlign; }
            set
            {
                this._ImageAlign = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public float Opacity
        {
            get { return this._Opacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                }
                if (value > 1)
                {
                    throw new ArgumentException("The opacity must be between 0 and 1", "value");
                }
                this._Opacity = value;
                this._TabControl.Invalidate();
            }
        }

        [Category("Appearance")]
        public int Overlap
        {
            get { return this._Overlap; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The tabs cannot have a negative overlap", "value");
                }
                this._Overlap = value;
            }
        }

        [Category("Appearance")]
        public Point Padding
        {
            get { return this._Padding; }
            set
            {
                this._Padding = value;
                //	This line will trigger the handle to recreate, therefore invalidating the control
                if (this._ShowTabCloser)
                {
                    if (value.X + (int)(this._Radius / 2) < -6)
                    {
                        ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                    }
                    else
                    {
                        ((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius / 2) + 6, value.Y);
                    }
                }
                else
                {
                    if (value.X + (int)(this._Radius / 2) < 1)
                    {
                        ((TabControl)this._TabControl).Padding = new Point(0, value.Y);
                    }
                    else
                    {
                        ((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius / 2) - 1, value.Y);
                    }
                }
            }
        }

        [Category("Appearance"), DefaultValue(1), Browsable(true)]
        public int Radius
        {
            get { return this._Radius; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The radius must be greater than 1", "value");
                }
                this._Radius = value;
                //	Adjust padding
                this.Padding = this._Padding;
            }
        }

        [Category("Appearance")]
        public bool ShowTabCloser
        {
            get { return this._ShowTabCloser; }
            set
            {
                this._ShowTabCloser = value;
                //	Adjust padding
                this.Padding = this._Padding;
            }
        }

        public static TabStyleProvider CreateProvider(Chrome tabControl)
        {
            //	Depending on the display style of the tabControl generate an appropriate provider.
            if (tabControl.DisplayStyle == TabStyle.Chrome)
            {
                return new TabStyleChromeProvider(tabControl);
            }

            return new TabStyleAngledProvider(tabControl);
        }

        #endregion Factory Methods

        #region overridable Methods

        public abstract void AddTabBorder(GraphicsPath path, Rectangle tabBounds);

        public GraphicsPath GetTabBorder(int index)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle tabBounds = this.GetTabRect(index);

            this.AddTabBorder(path, tabBounds);

            path.CloseFigure();
            return path;
        }

        public virtual Rectangle GetTabRect(int index)
        {
            if (index < 0)
            {
                return new Rectangle();
            }
            Rectangle tabBounds = this._TabControl.GetTabRect(index);
            if (this._TabControl.RightToLeftLayout)
            {
                tabBounds.X = this._TabControl.Width - tabBounds.Right;
            }
            bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);

            //	Expand to overlap the tabpage
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    tabBounds.Height += 2;
                    break;

                case TabAlignment.Bottom:
                    tabBounds.Height += 2;
                    tabBounds.Y -= 2;
                    break;

                case TabAlignment.Left:
                    tabBounds.Width += 2;
                    break;

                case TabAlignment.Right:
                    tabBounds.X -= 2;
                    tabBounds.Width += 2;
                    break;
            }

            //	Greate Overlap unless first tab in the row to align with tabpage
            if ((!firstTabinRow || this._TabControl.RightToLeftLayout) && this._Overlap > 0)
            {
                if (this._TabControl.Alignment <= TabAlignment.Bottom)
                {
                    tabBounds.X -= this._Overlap;
                    tabBounds.Width += this._Overlap;
                }
                else
                {
                    tabBounds.Y -= this._Overlap;
                    tabBounds.Height += this._Overlap;
                }
            }

            //	Adjust first tab in the row to align with tabpage
            this.EnsureFirstTabIsInView(ref tabBounds, index);

            return tabBounds;
        }

        public void PaintTab(int index, Graphics graphics)
        {
            using (GraphicsPath tabpath = this.GetTabBorder(index))
            {
                using (Brush fillBrush = this.GetTabBackgroundBrush(index))
                {
                    //	Paint the background
                    graphics.FillPath(fillBrush, tabpath);

                    //	Paint a focus indication
                    if (this._TabControl.Focused)
                    {
                        this.DrawTabFocusIndicator(tabpath, index, graphics);
                    }

                    //	Paint the closer
                    this.DrawTabCloser(index, graphics);
                }
            }
        }

        protected static GraphicsPath GetCloserPath(Rectangle closerRect)
        {
            GraphicsPath closerPath = new GraphicsPath();
            closerPath.AddLine(closerRect.X, closerRect.Y, closerRect.Right, closerRect.Bottom);
            closerPath.CloseFigure();
            closerPath.AddLine(closerRect.Right, closerRect.Y, closerRect.X, closerRect.Bottom);
            closerPath.CloseFigure();

            return closerPath;
        }

        protected virtual void DrawTabCloser(int index, Graphics graphics)
        {
            if (this._ShowTabCloser)
            {
                Rectangle closerRect = this._TabControl.GetTabCloserRect(index);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath closerPath = TabStyleProvider.GetCloserPath(closerRect))
                {
                    if (closerRect.Contains(this._TabControl.MousePosition))
                    {
                        using (Pen closerPen = new Pen(this._CloserColorActive))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                    else
                    {
                        using (Pen closerPen = new Pen(this._CloserColor))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
        protected virtual void EnsureFirstTabIsInView(ref Rectangle tabBounds, int index)
        {
            //	Adjust first tab in the row to align with tabpage
            //	Make sure we only reposition visible tabs, as we may have scrolled out of view.

            bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);

            if (firstTabinRow)
            {
                if (this._TabControl.Alignment <= TabAlignment.Bottom)
                {
                    if (this._TabControl.RightToLeftLayout)
                    {
                        if (tabBounds.Left < this._TabControl.Right)
                        {
                            int tabPageRight = this._TabControl.GetPageBounds(index).Right;
                            if (tabBounds.Right > tabPageRight)
                            {
                                tabBounds.Width -= (tabBounds.Right - tabPageRight);
                            }
                        }
                    }
                    else
                    {
                        if (tabBounds.Right > 0)
                        {
                            int tabPageX = this._TabControl.GetPageBounds(index).X;
                            if (tabBounds.X < tabPageX)
                            {
                                tabBounds.Width -= (tabPageX - tabBounds.X);
                                tabBounds.X = tabPageX;
                            }
                        }
                    }
                }
                else
                {
                    if (this._TabControl.RightToLeftLayout)
                    {
                        if (tabBounds.Top < this._TabControl.Bottom)
                        {
                            int tabPageBottom = this._TabControl.GetPageBounds(index).Bottom;
                            if (tabBounds.Bottom > tabPageBottom)
                            {
                                tabBounds.Height -= (tabBounds.Bottom - tabPageBottom);
                            }
                        }
                    }
                    else
                    {
                        if (tabBounds.Bottom > 0)
                        {
                            int tabPageY = this._TabControl.GetPageBounds(index).Location.Y;
                            if (tabBounds.Y < tabPageY)
                            {
                                tabBounds.Height -= (tabPageY - tabBounds.Y);
                                tabBounds.Y = tabPageY;
                            }
                        }
                    }
                }
            }
        }

        protected virtual Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush fillBrush = null;

            //	Capture the colours dependant on selection state of the tab
            Color dark = ColorScheme.BackColorEnd;
            Color light = ColorScheme.BackColorBegin;

            if (this._TabControl.SelectedIndex == index)
            {
                dark = Color.FromArgb(60, ColorScheme.BackColorEnd);
                light = Color.FromArgb(60, ColorScheme.BackColorBegin);
            }
            else if (!this._TabControl.TabPages[index].Enabled)
            {
                light = dark;
            }
            else if (index == this._TabControl.ActiveIndex)
            {
                //	Enable hot tracking
                light = ColorScheme.BackColorHoverBegin;
                dark = ColorScheme.BackColorHoverEnd;
            }

            //	Get the correctly aligned gradient
            Rectangle tabBounds = this.GetTabRect(index);

            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    if (this._TabControl.SelectedIndex == index)
                    {
                        dark = light;
                    }
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;

                case TabAlignment.Bottom:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;

                case TabAlignment.Left:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
                    break;

                case TabAlignment.Right:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
                    break;
            }

            //	Add the blend
            fillBrush.Blend = this.GetBackgroundBlend();

            return fillBrush;
        }

        #endregion overridable Methods

        #region Painting

        private void DrawTabFocusIndicator(GraphicsPath tabpath, int index, Graphics graphics)
        {
            if (this._FocusTrack && this._TabControl.Focused && index == this._TabControl.SelectedIndex)
            {
                Brush focusBrush = null;
                RectangleF pathRect = tabpath.GetBounds();
                Rectangle focusRect = Rectangle.Empty;
                switch (this._TabControl.Alignment)
                {
                    case TabAlignment.Top:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, (int)pathRect.Width, 4);
                        focusBrush = new LinearGradientBrush(focusRect, this._FocusColor, SystemColors.Window, LinearGradientMode.Vertical);
                        break;

                    case TabAlignment.Bottom:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Bottom - 4, (int)pathRect.Width, 4);
                        focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Vertical);
                        break;

                    case TabAlignment.Left:
                        focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, 4, (int)pathRect.Height);
                        focusBrush = new LinearGradientBrush(focusRect, this._FocusColor, SystemColors.ControlLight, LinearGradientMode.Horizontal);
                        break;

                    case TabAlignment.Right:
                        focusRect = new Rectangle((int)pathRect.Right - 4, (int)pathRect.Y, 4, (int)pathRect.Height);
                        focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Horizontal);
                        break;
                }

                //	Ensure the focus stip does not go outside the tab
                Region focusRegion = new Region(focusRect);
                focusRegion.Intersect(tabpath);
                graphics.FillRegion(focusBrush, focusRegion);
                focusRegion.Dispose();
                focusBrush.Dispose();
            }
        }

        #endregion Painting

        #region Background brushes

        private Blend GetBackgroundBlend()
        {
            float[] relativeIntensities = new float[] { 0f, 0.7f, 1f };
            float[] relativePositions = new float[] { 0f, 0.6f, 1f };

            //	Glass look to top aligned tabs

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;

            return blend;
        }

        #endregion Background brushes
    }
}