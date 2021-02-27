using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    public partial class White
    {
        public Color FrmLock_TxtFillColor { get { return SystemColors.Window; } }
        public Color FrmLock_TxtRectColor { get { return Color.FromArgb(65, 75, 101); } }
        public Color FrmLock_TxtForeColor { get { return SystemColors.WindowText; } }
        public Color FrmLock_btnFillColor { get { return SystemColors.Control; } }
        public Color FrmLock_btnForeColor { get { return SystemColors.ControlText; } }
        public Color FrmLock_btnRectColor { get { return Color.FromArgb(65, 75, 101); } }
    }
}
