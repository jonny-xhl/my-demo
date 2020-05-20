using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jonny.AllDemo.Auth.Requirement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Jonny.AllDemo.Auth
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
            services.AddControllers();
            services.AddAuthorization(options =>
            {
                //在这里添加授权策略（角色、身份、自定义策略等）
                //1、角色授权
                //2、基于Claime授权
                options.AddPolicy("CliamManage", builder => builder.RequireClaim("ManageId"));
                //3、策略授权（自定义策略继承AuthorizationHandler<TRequirement>，实现IAuthorizationRequirement）
                options.AddPolicy("RequimentManage", builder => builder.Requirements.Add(new ManageCliamRequiment()));
            }).AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "jonny",
                    ValidAudience = "jonny",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecret"))
                };
            });

            //services.AddIdentity(options =>
            //{
            //    options.SignIn = new Microsoft.AspNetCore.Identity.SignInOptions()
            //    {
            //        RequireConfirmedAccount = "admin"
            //    };
            //});

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("openapi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "统一身份认证API",
                    Description = "身份认证和授权详解",
                    Version = "v1"
                });
                var scheme = new OpenApiSecurityScheme()
                {
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    //头名称
                    Name = ApiKeyConstants.HeaderName,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Bearer Token"
                };
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, scheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddSingleton<ICustomAuthenticationManager, CustomAuthenticationManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //身份认证中间件(踩坑：授权中间件必须在认证中间件之前)
            app.UseAuthentication();

            //授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                //配置swagger端点
                options.SwaggerEndpoint("swagger/openapi/swagger.json", "openapi v1");
            });
        }
    }

    internal class ApiKeyConstants
    {
        public const string HeaderName = "Authorization";
    }
}
