using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Alsync.Infrastructure.Mvc.Middleware
{
    /// <summary>
    /// 表示防盗链中间件。
    /// </summary>
    public class AntiLeechMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AntiLeechOptions _options;

        /// <summary>
        /// 初始化 <see cref="AntiLeechMiddleware"/> 类的新实例。
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public AntiLeechMiddleware(RequestDelegate next, AntiLeechOptions options)
        {
            this._next = next;
            this._options = options ?? new AntiLeechOptions();
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var ext = Path.GetExtension(request.Path.Value);
            var imageExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
            if (!imageExtensions.Contains(ext))//非图片类型文件，不作处理
                await this._next(context);
            else
            {
                var requestHeaders = request.GetTypedHeaders();
                var referer = requestHeaders.Referer?.AbsoluteUri;
                if (string.IsNullOrEmpty(referer)
                    || _options.Domains.Contains(referer))
                    await this._next(context);
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), _options.DefaultImagePath);
                    var fs = File.OpenRead(path);
                    var bytes = new byte[fs.Length];
                    await fs.ReadAsync(bytes, 0, bytes.Length);
                    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
