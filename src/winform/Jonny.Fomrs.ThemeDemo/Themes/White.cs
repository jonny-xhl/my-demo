using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    public partial class White :
        ITheme,
        IThemeBaseForm,
        IThemeFrmLock,
        IThemeUCFileItem
    {
        public int Code { get { return 1; } }
        /// <summary>
        /// 基本窗体背景色
        /// </summary>
        public Color BaseFormBackgroundColor { get { return SystemColors.Control; } }
        /// <summary>
        /// 基本窗体文字颜色
        /// </summary>
        public Color BaseFormForeColor { get { return SystemColors.ControlText; } }
        public Color BaseFormTitleColor { get { return SystemColors.ControlText; } }

        #region IThemeUCFileItem
        public Color UCFileItem_BackgroundColor { get { return Color.FromArgb(37, 41, 59); } }
        public Color UCFileItem_ForeColor { get { return Color.White; } }
        public Color UCFileItem_BoxColor => throw new NotImplementedException();
        public Image UCFileItem_Img1 => throw new NotImplementedException();
        public Image UCFileItem_Img2 => throw new NotImplementedException();
        public Image UCFileItem_Img3 => throw new NotImplementedException();
        public Image UCFileItem_Img4 => throw new NotImplementedException();
        public Image UCFileItem_Img5 => throw new NotImplementedException();

        #endregion

        /// <summary>
        /// 初始化操作
        /// </summary>
        public void Init()
        {
            //这里做一些修改主题时候的业务
        }
        #region 重写运算符
        /// <summary>
        /// 重写==
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(White lhs, ITheme rhs)
        {

            if (lhs == null && rhs == null)
                return true;
            else
            {
                if (lhs != null && rhs != null)
                {
                    if (lhs.Code == rhs.Code)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// 重写!=
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(White lhs, ITheme rhs)
        {

            if (lhs == null && rhs == null)
                return false;
            else
            {
                if (lhs != null && rhs != null)
                {
                    if (lhs.Code == rhs.Code)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj is ITheme)
            {
                if (Code == ((ITheme)obj).Code)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
