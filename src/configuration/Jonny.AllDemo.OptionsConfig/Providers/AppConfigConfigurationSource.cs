using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// 自定义ConfigurationSource，用于创建返回<see cref="IConfigurationProvider"/>,如何创建<see cref="IConfigurationSource"/>
    /// </summary>
    public class AppConfigConfigurationSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            // TODO:其实这里EnsureDefaults就是做了以下两句代码的执行
            EnsureDefaults(builder);
            //FileProvider = (FileProvider ?? builder.GetFileProvider());
            //OnLoadException = (OnLoadException ?? builder.GetFileLoadExceptionHandler());
            return new AppConfigConfigurationProvider(this);
        }
    }
}
