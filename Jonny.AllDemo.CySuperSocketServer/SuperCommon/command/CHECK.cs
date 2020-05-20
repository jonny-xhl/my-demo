using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CySuperSocketServer.SuperCommon.command
{
    public class CHECK : CommandBase<WeChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() != 1)
            {
                session.Send("The wrong format"+ CommonConsts.NewLine);
            }
            else
            {
                string sn = requestInfo.Parameters[0].ToString();
                if (string.IsNullOrEmpty(sn))
                    session.Send("The wrong sn"+ CommonConsts.NewLine);
                else
                {
                    //已用此SN注册的连接会替换Sesion
                    var session_client = session.AppServer.GetAllSessions().Where(c => c.SN == sn);
                    if (session_client != null)
                    {
                        foreach (var item in session_client)
                        {
                            item.Send("new check,To close the connection for you"+ CommonConsts.NewLine);
                            item.Close();
                        }
                    }
                    session.IsLogin = true;
                    session.SN = sn;
                    session.Send("连接服务器成功success"+ CommonConsts.NewLine);
                }
            }
        }
    }
}
