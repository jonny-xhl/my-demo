﻿using System;
using System.Linq;
using Jonny.AllDemo.NetCoreEnvironment.StartFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jonny.AllDemo.NetCoreEnvironment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //test json
            Console.WriteLine(configuration["ConnectionString:Default"]);
        }


        public void ConfigureServices(IServiceCollection services)
        {
            ////IMiddleware需要主动注册
            services.AddSingleton<AuthticationMiddleware>();
            services.AddSingleton<IStartupFilter, MyStartupFilter>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<HttpStatusMiddleware>();
            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapGet("login", async context => { await context.Response.WriteAsync("request success!"); });
            });
        }
    }
}