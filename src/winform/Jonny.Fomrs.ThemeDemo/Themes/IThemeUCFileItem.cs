using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    public interface IThemeUCFileItem : ITheme
    {
        Color UCFileItem_BackgroundColor { get; }
        Color UCFileItem_ForeColor { get; }
        Color UCFileItem_BoxColor { get; }
        Image UCFileItem_Img1 { get; }
        Image UCFileItem_Img2 { get; }
        Image UCFileItem_Img3 { get; }
        Image UCFileItem_Img4 { get; }
        Image UCFileItem_Img5 { get; }
    }
}
