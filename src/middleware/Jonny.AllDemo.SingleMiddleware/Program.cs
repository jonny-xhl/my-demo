using System;
using System.IO;
using System.Threading.Tasks;
using Jonny.AllDemo.SingleMiddleware.Middlewares;
using Jonny.AllDemo.SingleMiddleware.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jonny.AllDemo.SingleMiddleware
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder.UseUrls("http://0.0.0.0:5002");
                    webHostBuilder.ConfigureServices(service =>
                    {
                        service.AddMvc();

                        //IMiddleware需要主动注册
                        service.AddSingleton<MyExceptionMiddleware>();
                        
                        service.AddTransient<ITransientTestAppService, TransientTestAppService>()
                            .AddScoped<IProductAppService, ProductAppService>()
                            .AddSingleton<IOrderAppService, OrderAppService>();
                    });
                    webHostBuilder.Configure(builder =>
                    {
                        
                        builder.UseCustomerExcetions()
                            .UseUrlMiddleware();
                        
                        builder.UseRouting();
                        
                        builder.UseEndpoints(endpoint =>
                        {
                            endpoint.MapControllers();
                        });
                    });
                })
                .ConfigureLogging(loggerBuilder =>
                {
                    loggerBuilder.ClearProviders();
                    loggerBuilder.AddConsole();
                    loggerBuilder.SetMinimumLevel(LogLevel.Warning);
                })
                .Build()
                .Run();
        }
    }
}