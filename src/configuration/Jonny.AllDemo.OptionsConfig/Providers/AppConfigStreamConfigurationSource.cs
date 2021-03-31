using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public class AppConfigStreamConfigurationSource : StreamConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder) => new AppConfigStreamConfigurationProvider(this);
    }
}
