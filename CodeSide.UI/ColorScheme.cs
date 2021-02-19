using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSide.UI
{
    public class ColorScheme
    {
        public enum THEME
        {
            LIGHT,
            DARK
        }
        public static THEME Theme { get; set; } = THEME.LIGHT;

        public static Color BackColor => Theme == THEME.DARK ? Color.FromArgb(21, 21, 21) : Color.FromArgb(249, 249, 249);
        public static Color BorderColor => Theme == THEME.DARK ? Color.FromArgb(66, 66, 66) : Color.FromArgb(194, 194, 194);
        public static Color BackColorBegin => Theme == THEME.DARK ? Color.FromArgb(85, 85, 85) : Color.FromArgb(249, 249, 249);
        public static Color BackColorEnd => Theme == THEME.DARK ? Color.FromArgb(16, 16, 16) : Color.FromArgb(208, 208, 211);
        public static Color BackColorHoverBegin => Theme == THEME.DARK ? Color.FromArgb(99, 99, 99) : Color.FromArgb(255, 255, 255);
        public static Color BackColorHoverEnd => Theme == THEME.DARK ? Color.FromArgb(23, 23, 23) : Color.FromArgb(212, 212, 220);
        public static Color TextColor => Theme == THEME.DARK ? Color.FromArgb(255, 255, 255) : Color.FromArgb(22, 22, 22);
        public static Color TextColorSelected => Theme == THEME.DARK ? Color.FromArgb(244, 244, 244) : Color.FromArgb(33, 33, 33);
        public static Color TextColorDisabled => Theme == THEME.DARK ? Color.FromArgb(188, 188, 188) : Color.FromArgb(99, 99, 99);

    }
}
