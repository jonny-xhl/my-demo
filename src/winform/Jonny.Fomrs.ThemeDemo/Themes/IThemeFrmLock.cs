using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    public interface IThemeFrmLock : IThemeBaseForm
    {
        Color FrmLock_TxtFillColor { get; }
        Color FrmLock_TxtRectColor { get; }
        Color FrmLock_TxtForeColor { get; }
        Color FrmLock_btnFillColor { get; }
        Color FrmLock_btnForeColor { get; }
        Color FrmLock_btnRectColor { get; }

    }
}
