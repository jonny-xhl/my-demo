using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jonny.AllDemo.Rdlc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.printDialog.ShowDialog()== DialogResult.OK)
            {
                this.printDocument.Print();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintSetting_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
