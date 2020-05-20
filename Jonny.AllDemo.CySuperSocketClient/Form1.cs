using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Jonny.AllDemo.CySuperSocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private SocketClient client = new SocketClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            client.ClientRecive += Client_ClientRecive;
            //初始加载连接到服务器
            client.Connect("192.168.137.22", 2020);
            
            //连接初始化标识
            var common = Command.CheckWithParam + client.SN + Command.NewLine;
            WriteLog(common);
            client.Send(common);            
            client.Recive();
        }

        private void Client_ClientRecive(object sender, ReciveEventArgs e)
        {
            WriteLog(e.Data);
        }
        /// <summary>
        /// 呼叫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var common = Command.CallWithParam + client.SN + Command.NewLine;
            WriteLog(common);
            client.Send(common);
        }
        void WriteLog(string log)
        {
            Invoke(new Action(() =>
            {
                this.richTextBox1.AppendText(log);
            }));
        }
    }
}
