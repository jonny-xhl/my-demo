using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Jonny.AllDemo.NetCoreEnvironment.StartFilter
{
    public class AuthticationMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.Value == "/favicon.ico")
            {
                return Task.CompletedTask;
            }

            Console.WriteLine("开始判断是否有权限");
            var auth = context.User.Identity?.IsAuthenticated ?? false;
            if (auth || !string.IsNullOrEmpty(context.Request.Query["access_token"].ToString()))
            {
                Console.WriteLine("认证成功!");
                next(context);
            }
            else
            {
                //需要注入:Microsoft.AspNetCore.Authentication.IAuthenticationService
                //await context.ChallengeAsync();
                Console.WriteLine("认证失败!"); //不走下一个了
            }

            return Task.CompletedTask;
        }
    }
}