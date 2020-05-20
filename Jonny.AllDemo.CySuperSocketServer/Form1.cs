using Jonny.AllDemo.CySuperSocketServer.SuperCommon;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CloseReason = SuperSocket.SocketBase.CloseReason;

namespace Jonny.AllDemo.CySuperSocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
        }
        IBootstrap bootstrap = null;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bootstrap != null)
            {
                bootstrap.Stop();
            }
        }

        //窗体加载的时候开启监听
        private void Form1_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("Config/log4net.config"));
            //声明bootStrap实例
            bootstrap = BootstrapFactory.CreateBootstrap();
            //初始化
            if (!bootstrap.Initialize())
            {
                SetMessage("Failed to initialize!");
                return;
            }
            //开启服务
            var result = bootstrap.Start();

            if (result == StartResult.Failed)
            {
                SetMessage("Failed to start!");

                return;
            }
            else
            {
                SetMessage("服务器启动成功");
            }
        }
        public void SetMessage(string msg)
        {
            Invoke(new Action(() => { this.richTextBox1.AppendText(msg + "\r\n"); }));
        }
    }
}
