using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Jonny.AllDemo.NetCoreEnvironment.StartFilter
{
    public class HttpStatusMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpStatusMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("认证成功-->状态码:{0}", context.Response.StatusCode);
            // await context.Response.WriteAsync(context.Response.StatusCode + "");
            await _next(context);
        }
    }
}