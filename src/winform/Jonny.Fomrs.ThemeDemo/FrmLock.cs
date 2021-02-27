using Jonny.Fomrs.ThemeDemo.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jonny.Fomrs.ThemeDemo
{
    public partial class FrmLock : FrmWithTitle
    {
        public FrmLock()
        {
            InitializeComponent();
        }

        private void RadioGroup_Click(object sender, EventArgs e)
        {
            var currentRadio = (RadioButton)sender;
            switch (currentRadio.Text)
            {
                case "深色":
                    Theme.CurrentTheme = new Dark();
                    break;
                default:
                    Theme.CurrentTheme = new White();
                    break;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FrmLock_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ThisTheme = Theme.CurrentTheme;
            }
        }
    }
}
