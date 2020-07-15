using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.SQLiteFirst
{
    public class NoteDto
    {
        public NoteDto(string seq, string business, string window, int wait)
        {
            Seq = seq;
            BusinessName = business;
            WindowsNames = window;
            WaitCount = wait;
        }
        /// <summary>
        /// 号码
        /// </summary>
        public string Seq { get; private set; }
        /// <summary>
        /// 业务名称
        /// </summary>
        public string BusinessName { get; private set; }

        /// <summary>
        /// 受理窗口
        /// </summary>
        public string WindowsNames { get; private set; }

        /// <summary>
        /// 等候总人数
        /// </summary>
        public int WaitCount { get; private set; }
    }
}
