using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.Api
{
    public class JetBrainsAnnotations : OutClass
    {
        public WeatherForecast Instance => throw new NotImplementedException();

        public string Length([NotNull] string str)
        {
            return str.Length.ToString();
        }
    }
}
