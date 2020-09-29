using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Jonny.AllDemo.NetCoreEnvironment.EnviromentStartup
{
    public class ProductionStartup : IStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("ProductionStartup.Configure");
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ProductionStartup.ConfigureServices");
            return null;
        }
    }
}