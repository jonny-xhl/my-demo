using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jonny.AllDemo.CyClientEngine
{
    public class CallMessageFilter : TerminatorReceiveFilter<StringPackageInfo>
    {
        public CallMessageFilter() : base(Encoding.UTF8.GetBytes(","))
        {
        }
        public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            throw new NotImplementedException();
        }
    }
}
