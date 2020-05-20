using System;
using System.Collections.Generic;
using System.IO;
using Jonny.AllDemo.OptionsConfig.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Jonny.AllDemo.OptionsConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 根路径输出
            {
                //Console.WriteLine($"AppContext.BaseDirectory:\t\t{AppContext.BaseDirectory}");
                //Console.WriteLine($"Environment.CurrentDirectory:\t\t{Environment.CurrentDirectory}");
                //Console.WriteLine($"AppDomain.CurrentDomain.BaseDirectory:\t{AppDomain.CurrentDomain.BaseDirectory}");
                //Console.WriteLine($"Directory.GetCurrentDirectory:\t\t{Directory.GetCurrentDirectory()}");
            }
            #endregion
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            #region 注册各种配置方式
            //Microsoft.Extensions.Configuration.Json包
            builder.AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
            //Microsoft.Extensions.Configuration.Ini包
            builder.AddIniFile("appsetting.ini", optional: false, reloadOnChange: true);
            //Microsoft.Extensions.Configuration包
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"Name","Jonny" },
                {"Age","25" },
                {"Gender","Male" },
                {"Address:Address1","重庆奉节" },
                {"Address:Address2","重庆渝北" }
            });
            //Microsoft.Extensions.Configuration.EnvironmentVariables包
            builder.AddEnvironmentVariables();
            #endregion
            #region 内存配置的读取
            {
                //Console.WriteLine("=======================内存配置的读取======================");
                //var configRoot = builder.Build();
                //Console.WriteLine($"Name:{configRoot["Name"]}");
                //Console.WriteLine($"Age:{configRoot["Age"]}");
                //Console.WriteLine($"Gender:{configRoot["Gender"]}");
                ////这里读取出Address节点下内容
                //var addressRoot = configRoot.GetSection("Address");
                //Console.WriteLine($"Address__Address1:{addressRoot["Address1"]}");
                //Console.WriteLine($"Address__Address2:{addressRoot["Address2"]}");
            }
            #endregion
            #region JSON配置的读取
            {
                //Console.WriteLine("=======================JSON配置的读取======================");
                //var configRoot = builder.Build();
                //var appConfigRoot = configRoot.GetSection("AppConfig");
                //Console.WriteLine($"AppConfig__RemoteService:{appConfigRoot["RemoteService"]}");
                //var hospitalRoot = appConfigRoot.GetSection("Hospital");
                //Console.WriteLine($"AppConfig__Hospital__Name:{hospitalRoot["Name"]}");
                //Console.WriteLine($"AppConfig__Hospital__Tel:{hospitalRoot["Tel"]}");
                ////这里通过一步到位获取一个值
                //Console.WriteLine($"AppConfig__Hospital__Level:{configRoot["AppConfig:Hospital:Level"]}");
                ////解释一下这里为什么用__来分隔，因为在Linux中:就是用双下划线__来替换的
            }
            #endregion
            #region INI配置的读取
            {
                //Console.WriteLine("=======================INI配置的读取======================");
                //var configRoot = builder.Build();
                //Console.WriteLine($"服务器__RemoteService:{configRoot["服务器:RemoteService"]}");
                //Console.WriteLine($"服务器__Account:{configRoot["服务器:Account"]}");
            }
            #endregion
            #region 使用ChangeToken热更新监控配置改变
            {
                var configRoot = builder.Build();
                //var token = configRoot.GetReloadToken();
                //token.RegisterChangeCallback(state =>
                //{
                //    Console.WriteLine($"【{configRoot["AppConfig:Hospital:Name"]}】服务配置发生了变化一次");
                //    var token1 = configRoot.GetReloadToken();
                //    token1.RegisterChangeCallback(state1=>
                //    {
                //        Console.WriteLine($"【{configRoot["AppConfig:Hospital:Name"]}】服务配置发生了变化两次");
                //    }, configRoot);
                //}, configRoot);
                //ChangeToken.OnChange(() => configRoot.GetReloadToken(), () =>
                //{
                //    Console.WriteLine($"【{configRoot["AppConfig:Hospital:Name"]}】服务配置发生了变化");
                //});
                //Console.WriteLine($"【{configRoot["AppConfig:Hospital:Name"]}】服务启动完成");
            }
            #endregion
            #region 命令行配置
            {
                //Console.WriteLine("=======================命令行配置======================");
                //必须以-开头或--开头，不能重复
                //Microsoft.Extensions.Configuration.CommandLine包            
                //builder.AddCommandLine(args);
                //使用-c替换掉CommandLine1
                //var replaceCommond = new Dictionary<string, string>
                //{
                //    {"-c","CommandLine1" }
                //};
                //builder.AddCommandLine(args, replaceCommond);
                //var configRoot = builder.Build();
                //Console.WriteLine($"CommandLine1:{configRoot["CommandLine1"]}");
                //Console.WriteLine($"CommandLine2:{configRoot["CommandLine2"]}");
            }
            #endregion
            #region 环境变量配置
            {
                //Console.WriteLine("=======================环境变量配置======================");
                //var configRoot = builder.Build();
                //Console.WriteLine($"ASPNETCORE_ENVIRONMENT:{configRoot["ASPNETCORE_ENVIRONMENT"]}");
                //Console.WriteLine($"系统环境变量Path:{configRoot["Path"]}");
            }
            #endregion
            #region 实体绑定+验证+修改配置
            {
                var configRoot = builder.Build();
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddScoped<IUserAppService, UserAppService>();
                        //services.AddSingleton<IUserAppService, UserAppService>();
                        var defaultOption = configRoot.GetSection("IdentityClients:Default");
                        //绑定实体
                        {
                            //这种方式任何生命周期注册都可以使用IOptions IOptionsSnapshot IOptionsMonitor
                            //services.AddOptions<IdentityClientOption>().Bind(defaultOption);
                            //使用Configure的方式绑定
                            //services.Configure<IdentityClientOption>(defaultOption);

                            //验证--通过Validate()方法验证
                            services.AddOptions<IdentityClientOption>()
                            .Bind(defaultOption)
                            .ValidateDataAnnotations();
                            //.Validate(option =>
                            //{
                            //    if (option.GrantType == "password")
                            //    {
                            //        return true;
                            //    }
                            //    return false;
                            //});

                            //验证-- > 通过注册Validator来验证
                            //services.AddSingleton<IValidateOptions<IdentityClientOption>, IdentityValitate>();
                            //测试获取
                            var userApp = services.BuildServiceProvider().GetRequiredService<IUserAppService>();
                            var token = configRoot.GetReloadToken();
                            token.RegisterChangeCallback(state =>
                            {
                                var userNewApp = services.BuildServiceProvider().GetRequiredService<IUserAppService>();                                                     
                            }, configRoot);
                            var users = userApp.GetUsers();
                            foreach (var user in users)
                            {
                                Console.WriteLine($"用户列表{users.IndexOf(user)}:{user.ToString()}");
                            }
                        }
                        #region TryAdd服务
                        {
                            //当容器中注册了IUserAppService后是不会再注册的
                            //services.AddSingleton<IUserAppService, UserAppService>();
                            //services.TryAddScoped<IUserAppService, UserAppService>();                        
                        }
                        #endregion
                        #region 替换服务
                        {
                            //services.AddTransient<IUserAppService, UserAppNewService>();
                            //services.Replace(ServiceDescriptor.Scoped<IUserAppService, UserAppNewService>());
                            ////测试获取
                            //var userApp = services.BuildServiceProvider().GetRequiredService<IUserAppService>();
                            //var users = userApp.GetUsers();
                            //foreach (var user in users)
                            //{
                            //    Console.WriteLine($"用户列表{users.IndexOf(user)}:{user.ToString()}");
                            //}
                        }
                        #region 移除某一个所有注册的服务 
                        {
                            //每次都会添加一个新的
                            //services.AddTransient<IUserAppService, UserAppService>();
                            //services.AddScoped<IUserAppService, UserAppService>();
                            //services.AddTransient<IUserAppService, UserAppNewService>();
                            //Console.WriteLine("==========IUserAppService移除之前输出=============");
                            //var cnt1 = services.Count;
                            //Console.WriteLine($"IUserAppService移除前数量：{cnt1}");
                            //Console.WriteLine("IUserAppService详情：");
                            //var users1 = services.BuildServiceProvider().GetServices<IUserAppService>();
                            //foreach (var user in users1)
                            //{
                            //    Console.WriteLine($"Type:{user.GetType()}，HashCode：{user.GetHashCode()}");
                            //}
                            ////两种方式一致
                            //services.RemoveAll<IUserAppService>();
                            //services.RemoveAll(typeof(IUserAppService));

                            //Console.WriteLine("==========IUserAppService详情移除后输出=============");
                            //var cnt2 = services.Count;
                            //Console.WriteLine($"IUserAppService详情移除后数量：{cnt2}");
                            //Console.WriteLine("IUserAppService详情：");
                            //var users2 = services.BuildServiceProvider().GetServices<IUserAppService>();
                            //foreach (var user in users2)
                            //{
                            //    Console.WriteLine($"Type:{user.GetType()}，HashCode：{user.GetHashCode()}");
                            //}
                        }
                        #endregion
                        #region 泛型注册
                        {

                        }
                        #endregion
                        #endregion
                    }).Build().Run();

            }
            #endregion
            Console.ReadLine();
        }
    }
}
