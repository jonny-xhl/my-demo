using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public class AppConfigStreamConfigurationProvider : StreamConfigurationProvider
    {
        public AppConfigStreamConfigurationProvider(AppConfigStreamConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
