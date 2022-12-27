using System.Drawing;

namespace CodeSide.UI
{
    public class ColorScheme
    {
        public enum THEME
        {
            Light,
            Dark
        }
        public static THEME Theme { get; set; } = THEME.Light;

        public static Color BackColor => Theme == THEME.Dark ? Color.FromArgb(21, 21, 21) : Color.FromArgb(249, 249, 249);
        public static Color BorderColor => Theme == THEME.Dark ? Color.FromArgb(66, 66, 66) : Color.FromArgb(194, 194, 194);
        public static Color BackColorBegin => Theme == THEME.Dark ? Color.FromArgb(85, 85, 85) : Color.FromArgb(252, 252, 252);
        public static Color BackColorEnd => Theme == THEME.Dark ? Color.FromArgb(16, 16, 16) : Color.FromArgb(222, 222, 222);
        public static Color BackColorHoverBegin => Theme == THEME.Dark ? Color.FromArgb(99, 99, 99) : Color.FromArgb(255, 255, 255);
        public static Color BackColorHoverEnd => Theme == THEME.Dark ? Color.FromArgb(23, 23, 23) : Color.FromArgb(212, 212, 220);
        public static Color ForeColor => Theme == THEME.Dark ? Color.FromArgb(255, 255, 255) : Color.FromArgb(22, 22, 22);
        public static Color ForeColorActive => Theme == THEME.Dark ? Color.FromArgb(244, 244, 244) : Color.FromArgb(33, 33, 33);
        public static Color TextColorDisabled => Theme == THEME.Dark ? Color.FromArgb(188, 188, 188) : Color.FromArgb(99, 99, 99);

    }
}
