using System;

namespace HostConsoleDemo
{
    public class HelloOptions
    {
        public string SayStr { get; set; } = "Hello";

        //public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(2);
        /// <summary>
        /// 周期，单位：秒
        /// </summary>
        public int Interval { get; set; } = 2;

    }
}