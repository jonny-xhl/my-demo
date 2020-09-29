using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Jonny.AllDemo.NetCoreEnvironment.StartFilter
{
    public class MyStartupFilter:IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<AuthticationMiddleware>();
                next(app);
            };
        }
    }
}