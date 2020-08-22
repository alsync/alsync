using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Mvc.Filters
{
    public class WebApiActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                dynamic value = context.Result switch
                {
                    ObjectResult result => new { Result = true, Data = result.Value },
                    JsonResult result => new { Result = true, Data = result.Value },
                    ContentResult result => new { Result = true, Data = result.Content },
                    _ => new { Result = true }
                };
                context.Result = new JsonResult(value);
            }

            base.OnActionExecuted(context);
        }
    }
}
