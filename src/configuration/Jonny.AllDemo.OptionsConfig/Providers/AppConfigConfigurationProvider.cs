using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;
using System;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// 自定义实现读取App.config文件<see cref="ConfigurationProvider"/><seealso cref="IConfigurationProvider"/>
    /// </summary>
    public class AppConfigConfigurationProvider : FileConfigurationProvider
    {
        // 忽略大小写,保证配置项不区分大小写
        private static Dictionary<string, string> data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public AppConfigConfigurationProvider(FileConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            data.Clear();
            var document = new XmlDocument();
            document.Load(stream);
            #region appSettings
            var adds = document.SelectNodes("/configuration/appSettings/add");
            foreach (XmlNode node in adds)
            {
                var key = node.Attributes["key"]?.Value;
                var value = node.Attributes["value"]?.Value;
                //var lockItem = node.Attributes["lockItem"].Value;
                if (key != null)
                {
                    data.TryAdd(key, value);
                }
            }
            #endregion
            #region connectionStrings
            var conns = document.SelectNodes("/configuration/connectionStrings/add");
            foreach (XmlNode node in conns)
            {
                var key = node.Attributes["name"].Value;
                var value = node.Attributes["connectionString"].Value;
                data.TryAdd(key, value);
            }
            #endregion
            // TODO:给Data赋值，切记勿忘
            Data = data;
        }

        protected IDictionary<string, string> CurrentData => Data;
    }
}
