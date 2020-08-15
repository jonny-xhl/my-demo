using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // test 承载服务
            // 几个重要的对象IHostBuilder  IHost 
            CreateBuilder(args).Build().Run();
        }

        static IHostBuilder CreateBuilder(string[] args)
        {
            return new HostBuilder()
                // 宿主配置
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCommandLine(args);
                    builder.AddEnvironmentVariables();
                })
                //宿主程序配置
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsetting.json", false, true);
                    builder.AddJsonFile($"appsetting.{context.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddSingleton<IAppService, AppService>()
                        .AddHostedService<AppService>()
                        .AddOptions()
                        .Configure<HelloOptions>(context.Configuration.GetSection("HelloOptions"));
                })
                .ConfigureLogging((context, builder) =>
                {           
                    builder.AddConfiguration(context.Configuration.GetSection("Logging"))                    
                    .AddConsole();
                });
        }
    }
}