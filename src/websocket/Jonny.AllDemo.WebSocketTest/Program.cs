using SuperWebSocket;
using System;
using System.Collections.Generic;
using System.Web;

namespace Jonny.AllDemo.WebSocketTest
{
    class Program
    {
        static Dictionary<string, WebSocketSession> sessionDics = new Dictionary<string, WebSocketSession>();
        public static WebSocketServer ws = null;
        static void Main(string[] args)
        {
            Console.WriteLine("WebSocket服务");
            ws = new WebSocketServer();
            ws.NewSessionConnected += Ws_NewSessionConnected;
            ws.NewMessageReceived += Ws_NewMessageReceived;
            ws.NewDataReceived += Ws_NewDataReceived;
            ws.SessionClosed += Ws_SessionClosed;
            if (!ws.Setup("127.0.0.1", 1234))
            {
                Console.WriteLine("设置WebSocket服务侦听地址失败");
                return;
            }
            if (!ws.Start())
            {
                Console.WriteLine("启动WebSocket服务侦听失败");
                return;
            }
            Console.WriteLine("WebSocket启动服务成功");
            Console.ReadKey();
            // 停止
            ws.Stop();
        }

        private static void Ws_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {

        }

        private static void Ws_NewDataReceived(WebSocketSession session, byte[] value)
        {

        }

        private static void Ws_NewMessageReceived(WebSocketSession session, string toUsers)
        {
            var sessionName = GetSeesionName(session);
            var msg = string.Format("{0:HH:MM:ss} {1}说:{2}", DateTime.Now, sessionName, toUsers );
            Console.WriteLine(msg);
            // 这里的value为 to-user的值，例如给127.0.0.2,127.0.0.3发送消息
            var sessions = toUsers.Split(',');
            foreach (var user in sessions)
            {
                if (sessionDics.ContainsKey(sessionName))
                {
                    // 这里读取下一位的序号,出队。
                    var toClientMsg = "{seq:\"A001\"}";
                    sessionDics[sessionName].Send(toClientMsg);
                }
            }

        }

        private static void Ws_NewSessionConnected(WebSocketSession session)
        {
            var sessionName = GetSeesionName(session);
            Console.WriteLine("{0:HH:MM:ss}与客户端：{1}创建新会话", DateTime.Now, sessionName);
            // TODO 存储session会话
            if (!sessionDics.ContainsKey(sessionName))
            {
                sessionDics[sessionName] = session;
            }
        }

        private static string GetSeesionName(WebSocketSession session)
        {
            return session.Path.TrimStart('/');
        }
    }
}
