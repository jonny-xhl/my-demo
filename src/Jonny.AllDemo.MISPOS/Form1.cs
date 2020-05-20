using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jonny.AllDemo.MISPOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private PosinfDLL DLL = new PosinfDLL();

        private void btnSign_Click(object sender, EventArgs e)
        {

        }

        private void btn消费_Click(object sender, EventArgs e)
        {
#if DEBUG
            var req = "0012345678234567890100000000000120141212123412341234000002000                                                                                                                                                                                      ";
            var request = DLL.GetObject<MisPosRequest>(Encoding.Default.GetBytes(req));
            var response = new MisPosResponse();
            DLL.Consume00(request, ref response);
#endif

        }
        private bool lk = true;

        private void HandleClient(TcpClient tcpclient)
        {
            lock (tcpclient)
            {
                if (tcpclient == null)
                {
                    return;
                }
                // Buffer for reading data
                Byte[] bytes = new Byte[1024];
                String data = null;

                // Enter the listening loop.
                while (tcpclient.Connected)
                {
                    data = null;
                    NetworkStream stream = tcpclient.GetStream();
                    int i;
                    if ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.UTF8.GetString(bytes, 0, i);
                        Console.WriteLine(string.Format("收到{0}消息:{1}", tcpclient.Client.RemoteEndPoint, data));
                        var sign = Encoding.UTF8.GetBytes("POS签到" + Environment.NewLine);
                        stream.Write(sign, 0, sign.Length);
                        var start = Encoding.UTF8.GetBytes("开始消费" + Environment.NewLine);
                        stream.Write(start, 0, start.Length);
                        var s1 = Encoding.UTF8.GetBytes("刷卡中............." + Environment.NewLine);
                        stream.Write(s1, 0, s1.Length);
                        var s2 = Encoding.UTF8.GetBytes("支付密码中............" + Environment.NewLine);
                        stream.Write(s2, 0, s2.Length);
                        var s3 = Encoding.UTF8.GetBytes("输密码完成" + Environment.NewLine);
                        stream.Write(s3, 0, s3.Length);
                        var end = Encoding.UTF8.GetBytes("消费完成" + Environment.NewLine);
                        stream.Write(end, 0, end.Length);
                    }
                    tcpclient.Close();
                }
            }
        }
        private void btn开启监听_Click(object sender, EventArgs e)
        {
            var settings = ConfigurationManager.AppSettings;
            #region 第二种
            //IPAddress ip = IPAddress.Parse(settings["serverIp"]);

            //TcpListener server = new TcpListener(ip, int.Parse(settings["serverPort"]));
            //server.Start();

            //Thread tasks = new Thread(() =>
            //{
            //    TcpClient client = null;
            //    while (lk)
            //    {
            //        Thread.Sleep(0);
            //        client = server.AcceptTcpClient();
            //        HandleClient(client);
            //        //tasks.Start(() => HandleClient(client, ipaddress)).Wait();
            //    }
            //});
            //tasks.Start();
            //this.btn开启监听.Enabled = false;
            //this.btn开启监听.Text = "监听成功";
            #endregion
            #region 第一种========
            #region 启动服务
            TcpListener server = new TcpListener(IPAddress.Parse(settings["serverIp"]), int.Parse(settings["serverPort"]));
            server.Start();
            Console.WriteLine("POS服务：【" + server.LocalEndpoint + "】已启动，请勿关闭此程序！");
            #endregion

            #region 监听并处理请求
            var th = new Thread(() =>
            {
                TcpClient client;
                while (true)
                {
                    Thread.Sleep(0);
                    try
                    {
                        client = server.AcceptTcpClient();
                        ThreadPool.QueueUserWorkItem(obj =>
                        {
                            DateTimeOffset kssj = DateTimeOffset.Now;
                            string ctInfo = string.Empty; //客户端ip和端口
                            try
                            {
                                lock (client)
                                {
                                    if (client == null)
                                    {
                                        return;
                                    }
                                    ctInfo = client.Client.RemoteEndPoint.ToString();
                                    // Buffer for reading data
                                    byte[] bytes = new byte[1024 * 200];
                                    using (client)
                                    {
                                        using (var stream = client.GetStream())
                                        {
                                            stream.Read(bytes, 0, bytes.Length);
                                            var recive = Encoding.UTF8.GetString(bytes).TrimEnd('\0');
                                            Console.WriteLine(string.Format("{0} {1}：{2}", ctInfo, DateTimeOffset.Now, recive));
                                            var send = Encoding.UTF8.GetBytes("消费完成");
                                            stream.Write(send, 0, send.Length);
                                            stream.Flush();//必须写
                                        }
                                    }
                                    client.Close();
                                }
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                            }
                            Console.WriteLine("时间：" + DateTime.Now.ToLongTimeString() + "连接：" + ctInfo + "耗时：" + (DateTimeOffset.Now - kssj).TotalMilliseconds);
                        }, client);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            });
            th.IsBackground = true;
            th.Start();
            this.btn开启监听.Enabled = false;
            this.btn开启监听.Text = "监听成功";
            #endregion
            #endregion

        }
    }
}
