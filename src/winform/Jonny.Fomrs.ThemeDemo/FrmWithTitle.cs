using Jonny.Fomrs.ThemeDemo.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jonny.Fomrs.ThemeDemo
{
    public partial class FrmWithTitle : Form, IThemeControl
    {
        public FrmWithTitle()
        {
            InitializeComponent();                        
            Theme.CheckedThemeEvent += Theme_CheckedThemeEvent;
        }        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected virtual void ChangeTheme(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control.HasChildren)
                {
                    ChangeTheme(control);
                }
                switch (control.GetType().Name)
                {
                    case "Button":
                        ((Button)control).BackColor = ((IThemeFrmLock)ThisTheme).FrmLock_btnFillColor;
                        ((Button)control).ForeColor = ((IThemeFrmLock)ThisTheme).FrmLock_btnForeColor;
                        break;
                    case "TextBox":
                        ((TextBox)control).BackColor = ((IThemeFrmLock)ThisTheme).FrmLock_TxtFillColor;
                        ((TextBox)control).ForeColor = ((IThemeFrmLock)ThisTheme).FrmLock_TxtForeColor;
                        break;
                    case "Label":
                        break;
                    default:
                        break;
                }
            }
        }
        ITheme thisTheme = null;
        /// <summary>
        /// 当前页面正在使用的主题
        /// </summary>
        public ITheme ThisTheme
        {
            get
            {
                if (thisTheme == null)
                {
                    thisTheme = Theme.CurrentTheme;
                }
                return thisTheme;
            }
            set
            {
                if (thisTheme != value)
                {
                    thisTheme = value;
                    Theme.LoadTheme(this);
                }
            }
        }

        public void ResetTheme()
        {
            var t = (IThemeFrmLock)ThisTheme;
            BackColor = t.BaseFormBackgroundColor;
            ChangeTheme(this);
        }
        private void Theme_CheckedThemeEvent(ITheme theme)
        {
            if (Visible)
            {
                ThisTheme = theme;
            }
        }
    }
}
