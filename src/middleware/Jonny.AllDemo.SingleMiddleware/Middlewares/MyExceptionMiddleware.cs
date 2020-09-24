using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Jonny.AllDemo.SingleMiddleware.Middlewares
{
    public sealed class MyExceptionMiddleware:IMiddleware
    {
        private int times = 1;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                Console.WriteLine($"请求{times++}次进入MyExceptionMiddleware中间件。hash:{this.GetHashCode()}");
                await next(context);
            }
            catch (Exception e)
            {
                await Task.CompletedTask;
            }
        }
    }
}