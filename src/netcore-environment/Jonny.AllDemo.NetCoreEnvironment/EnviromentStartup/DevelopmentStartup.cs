using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Jonny.AllDemo.NetCoreEnvironment.EnviromentStartup
{
    public class DevelopmentStartup:IStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("DevelopmentStartup.Configure");
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("DevelopmentStartup.ConfigureServices");
            return null;
        }
    }
}