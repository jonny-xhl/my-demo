using System;
using Jonny.AllDemo.NetCoreEnvironment.EnviromentConfig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Jonny.AllDemo.NetCoreEnvironment.EnviromentStartup;
using Microsoft.Extensions.Configuration;

namespace Jonny.AllDemo.NetCoreEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("JsonFile/appsetting.json");
                    builder.AddJsonFile($"JsonFile/appsetting.{context.HostingEnvironment.EnvironmentName}.json");
                })
                .ConfigureWebHostDefaults(builder =>
                {
                    //builder.UseStartup<StartupWithEnviromentConfig>();
                    builder.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }
}