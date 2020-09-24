using Microsoft.AspNetCore.Builder;

namespace Jonny.AllDemo.SingleMiddleware.Middlewares
{
    public static class UrlMiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UrlMiddleware>();
        }
    }
}