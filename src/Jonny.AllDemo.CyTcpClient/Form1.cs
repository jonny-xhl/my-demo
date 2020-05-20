using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jonny.AllDemo.CyTcpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ip = txtIP.Text;
            port = int.Parse(txtPort.Text);
        }
        string ip;
        int port;


        private void btn发送_Click(object sender, EventArgs e)
        {
            using (var client = new TcpClient(ip, port))
            {
                var msg = txtMsg.Text + Environment.NewLine;
                richTextBox1.AppendText(msg);
                var byteMsg = Encoding.UTF8.GetBytes(msg);
                byte[] buffer = new byte[1024 * 200];
                using (var stream = client.GetStream())
                {
                    stream.Write(byteMsg, 0, byteMsg.Length);
                    while (true)
                    {
                        Thread.Sleep(1);
                        var rdLength = stream.Read(buffer, 0, buffer.Length);
                        if (rdLength == 0)
                            break;
                    }
                    stream.Flush();
                    richTextBox2.AppendText(Encoding.UTF8.GetString(buffer).TrimEnd('\0') + Environment.NewLine);
                }
            }

        }
    }
}
