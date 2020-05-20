using Jonny.AllDemo.CySuperSocketServer.SuperCommon.command;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CySuperSocketServer
{
    /// <summary>
    /// 微信Session
    /// </summary>
    public class WeChatSession : AppSession<WeChatSession>
    {
        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin { get; set; }

        /// <summary>
        /// 机器编码
        /// </summary>
        public string SN { get; set; }

        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket WeChat Server"+ CommonConsts.NewLine);
        }

        protected override void OnInit()
        {
            this.Charset = Encoding.UTF8;
            base.OnInit();
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("不知道如何处理 " + requestInfo.Key.ToString() + " 命令"+ CommonConsts.NewLine);
        }


        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send("异常信息：{0}"+ CommonConsts.NewLine, e.Message);
            base.HandleException(e);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
