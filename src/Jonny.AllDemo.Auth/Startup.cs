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
                //�����������Ȩ���ԣ���ɫ����ݡ��Զ�����Եȣ�
                //1����ɫ��Ȩ
                //2������Claime��Ȩ
                options.AddPolicy("CliamManage", builder => builder.RequireClaim("ManageId"));
                //3��������Ȩ���Զ�����Լ̳�AuthorizationHandler<TRequirement>��ʵ��IAuthorizationRequirement��
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
                    Title = "ͳһ�����֤API",
                    Description = "�����֤����Ȩ���",
                    Version = "v1"
                });
                var scheme = new OpenApiSecurityScheme()
                {
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    //ͷ����
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
            //�����֤�м��(�ȿӣ���Ȩ�м����������֤�м��֮ǰ)
            app.UseAuthentication();

            //��Ȩ�м��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                //����swagger�˵�
                options.SwaggerEndpoint("swagger/openapi/swagger.json", "openapi v1");
            });
        }
    }

    internal class ApiKeyConstants
    {
        public const string HeaderName = "Authorization";
    }
}
