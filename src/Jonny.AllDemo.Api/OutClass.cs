using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.Api
{
    public interface OutClass : IOutInterface<WeatherForecast>
    {
        string Length([NotNull]string str);
    }
}
