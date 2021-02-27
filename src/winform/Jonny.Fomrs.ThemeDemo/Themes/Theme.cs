using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    /// <summary>
    /// 主题设置
    /// </summary>
    public class Theme
    {
        internal delegate void CheckedThemeEventHandle(ITheme theme);
        /// <summary>
        /// 改变主题事件
        /// </summary>
        static internal event CheckedThemeEventHandle CheckedThemeEvent;
        static ITheme currentTheme;
        /// <summary>
        /// 当前主题
        /// </summary>
        internal static ITheme CurrentTheme
        {
            get { return currentTheme; }
            set
            {
                if (value == null)
                    return;
                currentTheme = value;
                currentTheme.Init();
                if (CheckedThemeEvent != null)
                {
                    CheckedThemeEvent(value);
                }
            }
        }
        /// <summary>
        /// 加载控件的主题
        /// </summary>
        /// <param name="control"></param>
        internal static void LoadTheme(IThemeControl control)
        {
            control.ResetTheme();
        }
    }
}
