using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CySuperSocketServer
{
    public class WeChatServer : AppServer<WeChatSession>
    {
        public WeChatServer() : base(new CommandLineReceiveFilterFactory(Encoding.UTF8,
            new BasicRequestInfoParser(":", ",")))
        {

        }
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            //LogHelper.WriteLog("WeChat服务启动");
            Console.WriteLine("WeChat服务启动");
            base.OnStarted();

        }

        protected override void OnStopped()
        {
            //LogHelper.WriteLog("WeChat服务停止");
            Console.WriteLine("WeChat服务停止");
            base.OnStopped();
        }

        /// <summary>
        /// 新的连接
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(WeChatSession session)
        {
            //LogHelper.WriteLog("WeChat服务新加入的连接:" + session.LocalEndPoint.Address.ToString());
            base.OnNewSessionConnected(session);
        }

    }
}
