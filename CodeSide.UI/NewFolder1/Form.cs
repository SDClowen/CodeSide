using CodeSide.UI.Helpers;
using System;
using System.Windows.Forms;
using static NativeMethods;

namespace CodeSide.UI.Controls
{
    public class Form : System.Windows.Forms.Form
    {
        protected bool enableFullDraggable;

        /// <summary>
        /// Has aero enabled by windows <c>true</c>; otherwise <c>false</c>
        /// </summary>
        private bool _aeroEnabled
        {
            get
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    int enabled = 0;
                    DwmIsCompositionEnabled(ref enabled);
                    return enabled == 1;
                }

                return false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256 | msg.Msg == 260)
                if (keyData == Keys.Escape)
                    Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }


        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                if (!_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;

                return cp;
            }
        }

        public void ChangeControlsTheme(Control control)
        {
            if (control is RichTextBox || control is ListView || control is ListBox)
            {
                control.BackColor = ColorScheme.BackColor;
                control.ForeColor = ColorScheme.BackColor.Determine();
            }

            WindowsHelper.UseImmersiveDarkMode(control.Handle, ColorScheme.BackColor.IsDark());

            foreach (Control subControl in control.Controls)
            {
                ChangeControlsTheme(subControl);
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (DesignMode)
                return;

            ChangeControlsTheme(this);

            if (_aeroEnabled)
            {
                var v = 2;
                DwmSetWindowAttribute(Handle, 2, ref v, 4);
                var margins = new MARGINS()
                {
                    Bottom = 1,
                    Left = 1,
                    Right = 1,
                    Top = 1
                };

                DwmExtendFrameIntoClientArea(this.Handle, ref margins);

            }

            WindowsHelper.UseImmersiveDarkMode(Handle, ColorScheme.BackColor.IsDark());
            if (!WindowsHelper.IsModern)
                return;


            //EnableAcrylic(this, Color.FromArgb(0,0,0,0));

            var flag = DWMSBT_TABBEDWINDOW;
            DwmSetWindowAttribute(
                Handle,
                DWMWA_SYSTEMBACKDROP_TYPE,
                ref flag,
                sizeof(int));
        }
    }
}