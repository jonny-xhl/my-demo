using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jonny.AllDemo.NetCoreEnvironment.EnviromentConfig
{
    public class StartupWithEnviromentConfig
    {
        
        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureDevelopmentServices");
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureStagingServices");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureServices");
        }


        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            Console.WriteLine("ConfigureDevelopment");
        }

        public void ConfigureStaging(IApplicationBuilder app)
        {
            Console.WriteLine("ConfigureStaging");
        }

        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("Configure");
        }
    }
}