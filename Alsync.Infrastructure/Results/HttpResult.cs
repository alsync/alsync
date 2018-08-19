using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Results
{
    /// <summary>
    /// 表示Api统一返回类型的类。
    /// </summary>
    public class HttpResult
    {
        /// <summary>
        /// 获取或设置一个 <code>Boolean</code> 值，该值表示Http请求的结果。
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 获取或设置消息。
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 表示Api统一返回类型的类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResult<T> : HttpResult
    {
        /// <summary>
        /// 获取或设置数据。
        /// </summary>
        public T Data { get; set; }
    }
}
