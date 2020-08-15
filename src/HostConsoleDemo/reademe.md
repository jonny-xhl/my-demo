# 简要
通过**老A**的`服务承载系统`文章系列进行了学习并自行进行了测试，所以有了这么一个demo。详情的知识请阅读下面给出的地址。
# Host静态类
为什么会单独说下Host静态类呢？

本demo主要是对Host静态类中的默认实现`命令行、环境变量、日志、配置文件、ServiceProviderFactory`的实现。


`Host.CreateDefaultBuilder:`
```csharp
/// <summary>
/// Initializes a new instance of the <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" /> class with pre-configured defaults.
/// </summary>
/// <remarks>
///   The following defaults are applied to the returned <see cref="T:Microsoft.Extensions.Hosting.HostBuilder" />:
///   <list type="bullet">
///     <item><description>set the <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath" /> to the result of <see cref="M:System.IO.Directory.GetCurrentDirectory" /></description></item>
///     <item><description>load host <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from "DOTNET_" prefixed environment variables</description></item>
///     <item><description>load host <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from supplied command line args</description></item>
///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from 'appsettings.json' and 'appsettings.[<see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" />].json'</description></item>
///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from User Secrets when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development' using the entry assembly</description></item>
///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from environment variables</description></item>
///     <item><description>load app <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> from supplied command line args</description></item>
///     <item><description>configure the <see cref="T:Microsoft.Extensions.Logging.ILoggerFactory" /> to log to the console, debug, and event source output</description></item>
///     <item><description>enables scope validation on the dependency injection container when <see cref="P:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName" /> is 'Development'</description></item>
///   </list>
/// </remarks>
/// <param name="args">The command line args.</param>
/// <returns>The initialized <see cref="T:Microsoft.Extensions.Hosting.IHostBuilder" />.</returns>
public static IHostBuilder CreateDefaultBuilder(string[] args)
{
  HostBuilder hostBuilder = new HostBuilder();
  hostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
  hostBuilder.ConfigureHostConfiguration((Action<IConfigurationBuilder>) (config =>
  {
    config.AddEnvironmentVariables("DOTNET_");
    if (args == null)
      return;
    config.AddCommandLine(args);
  }));
  hostBuilder.ConfigureAppConfiguration((Action<HostBuilderContext, IConfigurationBuilder>) ((hostingContext, config) =>
  {
    IHostEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
    bool reloadOnChange = hostingContext.Configuration.GetValue<bool>("hostBuilder:reloadConfigOnChange", true);
    config.AddJsonFile("appsettings.json", true, reloadOnChange).AddJsonFile("appsettings." + hostingEnvironment.EnvironmentName + ".json", true, reloadOnChange);
    if (hostingEnvironment.IsDevelopment() && !string.IsNullOrEmpty(hostingEnvironment.ApplicationName))
    {
      Assembly assembly = Assembly.Load(new AssemblyName(hostingEnvironment.ApplicationName));
      if (assembly != (Assembly) null)
        config.AddUserSecrets(assembly, true);
    }
    config.AddEnvironmentVariables();
    if (args == null)
      return;
    config.AddCommandLine(args);
  })).ConfigureLogging((Action<HostBuilderContext, ILoggingBuilder>) ((hostingContext, logging) =>
  {
    bool flag = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    if (flag)
      logging.AddFilter<EventLogLoggerProvider>((Func<LogLevel, bool>) (level => level >= LogLevel.Warning));
    logging.AddConfiguration((IConfiguration) hostingContext.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();
    if (flag)
      logging.AddEventLog();
    logging.Configure((Action<LoggerFactoryOptions>) (options => options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId | ActivityTrackingOptions.TraceId | ActivityTrackingOptions.ParentId));
  })).UseDefaultServiceProvider((Action<HostBuilderContext, ServiceProviderOptions>) ((context, options) =>
  {
    bool flag = context.HostingEnvironment.IsDevelopment();
    options.ValidateScopes = flag;
    options.ValidateOnBuild = flag;
  }));
  return (IHostBuilder) hostBuilder;
}
```
# 参考地址
[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-01.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-01.html)

[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-02.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-02.html)

[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-03.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-03.html)

[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-04.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-04.html)

[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-05.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-05.html)

[https://www.cnblogs.com/artech/p/inside-asp-net-core-09-06.html](https://www.cnblogs.com/artech/p/inside-asp-net-core-09-06.html)

> 来自业界**老A**的《ASP.NET Core 3框架揭秘》内容