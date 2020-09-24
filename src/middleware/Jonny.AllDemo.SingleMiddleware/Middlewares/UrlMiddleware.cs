using System;
using System.Threading.Tasks;
using Jonny.AllDemo.SingleMiddleware.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Jonny.AllDemo.SingleMiddleware.Middlewares
{
    public sealed class UrlMiddleware
    {
        private int times = 1;
        private readonly RequestDelegate _next;
        public UrlMiddleware(RequestDelegate next,
            IProductAppService productAppService,
            ITransientTestAppService transientTestAppService)
        {
            //构造中的productAppService服务是由IApplicationBuilder.ApplicationServices根容器创建的
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IProductAppService productAppService,ITransientTestAppService transientTestAppService)
        {
            //invoke中的productAppService其实是context.RequestServices子容器创建的。
            //这里的context.RequestServices子容器也是由IApplicationBuilder.ApplicationServices根容器创建来的。
            Console.WriteLine($"请求第{times++}次进入UrlMiddleware中间件。hash:{this.GetHashCode()}");
            await _next(context);
        }
    }
}