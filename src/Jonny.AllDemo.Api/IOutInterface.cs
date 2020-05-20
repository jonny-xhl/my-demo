using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.Api
{
    public interface IOutInterface<out T>
    {
        T Instance { get; }
    }
}
