using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jonny.AllDemo.Picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool IsRunning = true;
        private void button1_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //    while (true)
            //    {
            //        if (!IsRunning)
            //        {
            //            break;
            //        }
            //        Console.WriteLine(IsRunning);
            //        Thread.Sleep(500);
            //    }
            //});
            ThreadPool.QueueUserWorkItem(state =>
            {
                for (; IsRunning; new Action(() =>
                 {
                     Thread.Sleep(500);
                 })())
                {
                    Console.WriteLine(IsRunning);
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsRunning = false;
        }
    }
}
