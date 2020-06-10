using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDem.Middleware.Attr
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            await context.HttpContext.Response.WriteAsync($"{nameof(ExceptionFilter)},{context.Exception?.Message}");
        }
    }


    public class MyExceptionAttribute : ActionFilterAttribute
    {

    }
}
