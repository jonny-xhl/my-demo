using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.MISPOS
{
    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = false)]
    public class IndexAttribute : Attribute
    {
        public int Index { get; set; }

        public IndexAttribute()
        {
            Index = 1;
        }

        public IndexAttribute(int index)
        {
            Index = index;
        }
    }
}
