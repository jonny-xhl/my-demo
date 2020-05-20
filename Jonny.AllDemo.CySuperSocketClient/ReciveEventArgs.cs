using System;

namespace Jonny.AllDemo.CySuperSocketClient
{
    public class ReciveEventArgs : EventArgs
    {
        public ReciveEventArgs()
        {

        }
        public ReciveEventArgs(string data)
        {
            Data = data;
        }
        public string Data { get; }
    }
}