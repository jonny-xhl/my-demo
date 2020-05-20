using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CySuperSocketServer.SuperCommon.command
{
    public class CALL : CommandBase<WeChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            if (session.IsLogin)
            {
                //获取是哪一个医生进行的叫号
                string sn = requestInfo.Parameters[0].ToString();
                if (string.IsNullOrEmpty(sn))
                    session.Send("The wrong sn" + CommonConsts.NewLine);
                else
                {
                    //已用此SN注册的连接会替换Sesion
                    var session_client = session.AppServer.GetAllSessions().FirstOrDefault(c => c.SN == sn);
                    if (session_client != null)
                    {
                        session_client.Send("[{\"PatientName\":\"张三\",\"Index\":\"13号\"}]" + CommonConsts.NewLine);
                        session_client.Close();
                    }
                }
            }
            else
            {
                session.Send("没有登录，请重新登录！" + CommonConsts.NewLine);
            }
        }
    }
}
