using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CySuperSocketClient
{
    public class Command
    {
        public const string Check = "CHECK";
        public const string CheckWithParam = "CHECK:";
        public const string CallWithParam = "CALL:";
        public const string Call = "CALL";
        public const string NewLine = "\r\n";
    }
}
