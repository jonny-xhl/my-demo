using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.MISPOS
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = false,
        Inherited = false)]
    public class LengthAttribute : Attribute
    {
        public int Len { get; set; }

        public LengthAttribute(int len)
        {
            Len = len;
        }
    }
}
