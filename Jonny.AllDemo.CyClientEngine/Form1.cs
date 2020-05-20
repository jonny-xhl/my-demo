using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Jonny.AllDemo.CyClientEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private EasyClient client = new EasyClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            client.BeginConnect(new IPEndPoint(IPAddress.Parse("192.168.137.22"), 2020));
            client.Initialize(new CallMessageFilter(), request =>
            {

            });
            if (client.IsConnected)
            {
                client.Send(GetBytes("CHECK:127.0.0.1\r\n"));
            }

        }
        byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
