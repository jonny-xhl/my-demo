using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Quickstart.UI;
using Jonny.AllDemo.GoogleAuthticationMvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jonny.AllDemo.GoogleAuthticationMvc
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
            services.AddControllersWithViews();

            // 这里采用Quickstart.UI Users
            services.AddIdentityServer()                
                .AddInMemoryIdentityResources(IdentityConfig.Ids)
                .AddInMemoryApiResources(IdentityConfig.Apis)
                .AddInMemoryClients(IdentityConfig.Clients)
                .AddTestUsers(TestUsers.Users);

            services.AddAuthentication()
                .AddGoogle("Google", build =>
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();  // 禁用整个应用程序匿名访问
            });
        }
    }
}
