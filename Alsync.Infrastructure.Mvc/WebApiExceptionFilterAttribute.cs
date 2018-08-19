using Alsync.Infrastructure.Exceptions;
using Alsync.Infrastructure.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Alsync.Infrastructure.Mvc
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception != null)
            {
                if (exception is ValidationException)
                {
                    var args = new HttpResult { Result = false, Message = exception.Message };

                    context.HttpContext.Response.ContentType = "text/plain";
                    await context.HttpContext.Response.WriteAsync("Status code page, status code: " + context.HttpContext.Response.StatusCode);
                }
            }
            //await base.OnExceptionAsync(context);
        }
    }
}
