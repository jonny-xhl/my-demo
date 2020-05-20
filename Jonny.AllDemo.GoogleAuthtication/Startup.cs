using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Google;
using IdentityServer4;

namespace Jonny.AllDemo.GoogleAuthtication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddAuthentication()
                .AddGoogle("Google",build =>
                {
                    build.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    build.ClientId = "841866015174-26rgmvcosecqa65qnhk93b2tlrboeqbp.apps.googleusercontent.com";
                    build.ClientSecret = "Wkdk76v1ps3bIxo2TZrKsi3B";
                });

            // 采用自定义Cookie处理程序
            //services.AddAuthentication()
            //    .AddCookie("google-cookie")
            //    .AddGoogle("Google", build =>
            //    {
            //        build.SignInScheme = "google-cookie";
            //        build.ClientId = "841866015174-26rgmvcosecqa65qnhk93b2tlrboeqbp.apps.googleusercontent.com";
            //        build.ClientSecret = "Wkdk76v1ps3bIxo2TZrKsi3B";
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
