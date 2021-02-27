using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    /// <summary>
    /// 使用主题的控件、窗体需要实现此接口
    /// </summary>
    public interface IThemeControl
    {
        ITheme ThisTheme { get; set; }
        /// <summary>
        /// 重置主题
        /// </summary>
        void ResetTheme();
    }
}
