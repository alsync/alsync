using Alsync.Infrastructure.Mvc.Middleware;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class AntiLeechApplicationBuilderExtensions
    {
        /// <summary>
        /// 添加防盗链中间件。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAntiLeech(this IApplicationBuilder app, Action<AntiLeechOptions> setupAction)
        {
            var options = new AntiLeechOptions();
            setupAction?.Invoke(options);

            app.UseMiddleware<AntiLeechMiddleware>(options);

            return app;
        }
    }
}
