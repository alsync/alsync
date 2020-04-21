using Alsync.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

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
                    var result = new { Result = false, Message = exception.Message };
                    context.Result = new JsonResult(result);
                }
                else
                {
                    //var result = new { Result = false, Message = exception.Message };
                    //context.Result = new JsonResult(result);

                    //context.HttpContext.Response.ContentType = "application/json";
                    //await context.HttpContext.Response.WriteAsync("Status code page, status code: " + context.HttpContext.Response.StatusCode);
                }
            }
            //context.ExceptionHandled = true;
            await base.OnExceptionAsync(context);
        }
    }
}
