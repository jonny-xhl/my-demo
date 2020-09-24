using Microsoft.AspNetCore.Builder;

namespace Jonny.AllDemo.SingleMiddleware.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomerExcetions(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyExceptionMiddleware>();
        }
    }
}