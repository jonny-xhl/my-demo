using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Jonny.AllDemo.CySuperSocketClient
{
    public class SocketClient
    {
        private static Socket client;
        private readonly static object _lock = new object();
        public event EventHandler<ReciveEventArgs> ClientRecive;
        public string SN { get; private set; }
        public Socket Instance
        {
            get
            {
                if (client == null)
                {
                    lock (_lock)
                    {
                        if (client == null)
                        {
                            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        }
                    }
                }
                return client;
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void Connect(string address, int port)
        {
            IPAddress ip;
            if (!IPAddress.TryParse(address, out ip))
            {
                throw new SocketException(1000);
            }
            Instance.Connect(ip, port);
            SN = address;
        }

        public void Send(string msg)
        {
            var buffter = Encoding.UTF8.GetBytes(msg);
            Instance.Send(buffter);
            Thread.Sleep(1000);
        }
        public void Recive()
        {
            byte[] buffer;
            int effective;
            while (true)
            {
                //获取发送过来的消息
                buffer = new byte[1024 * 1024 * 2];
                effective = Instance.Receive(buffer);
                if (effective != 0)
                {
                    var str = Encoding.UTF8.GetString(buffer, 0, effective);
                    ClientRecive.Invoke(this, new ReciveEventArgs(str));
                    Thread.Sleep(2000);
                }
            }

        }
    }
}
