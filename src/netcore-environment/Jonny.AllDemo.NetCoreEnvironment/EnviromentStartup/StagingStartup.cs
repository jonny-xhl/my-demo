using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Jonny.AllDemo.NetCoreEnvironment.EnviromentStartup
{
    public class StagingStartup : IStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("StagingStartup.Configure");
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("StagingStartup.ConfigureServices");
            return null;
        }
    }
}