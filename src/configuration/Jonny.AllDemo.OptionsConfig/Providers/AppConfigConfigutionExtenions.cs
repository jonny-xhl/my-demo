using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Microsoft.Extensions.Configuration
{
    public static class AppConfigConfigutionExtenions
    {
        public static IConfigurationBuilder AddAppConfigFile(this IConfigurationBuilder builder, string path)
        {
            return builder.AddAppConfigFile(null, path, false, false);
        }

        public static IConfigurationBuilder AddAppConfigFile(this IConfigurationBuilder builder, string path, bool optional)
        {
            return builder.AddAppConfigFile(null, path, optional, false);
        }

        public static IConfigurationBuilder AddAppConfigFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            return builder.AddAppConfigFile(null, path, optional, reloadOnChange);
        }

        public static IConfigurationBuilder AddAppConfigFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("路径不能为空", nameof(path));
            return builder.AddAppConfigFile(s =>
            {
                //s.FileProvider = provider ?? builder.GetFileProvider();
                ///<see cref="AppConfigConfigurationSource.Build(IConfigurationBuilder)"/>
                s.FileProvider=provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        public static IConfigurationBuilder AddAppConfigFile(this IConfigurationBuilder builder, Action<AppConfigConfigurationSource> configureSource)
        {
            return builder.Add(configureSource);
        }

        public static IConfigurationBuilder AddAppConfigStream(this IConfigurationBuilder builder, Stream stream)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            return builder.Add((Action<AppConfigStreamConfigurationSource>)(s => s.Stream = stream));
        }
    }
}
