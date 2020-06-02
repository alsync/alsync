using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示用户开放平台的对象。
    /// </summary>
    public class UserOpenPlatform : AggregateRoot
    {
        /// <summary>
        /// 获取或设置开发平台。
        /// </summary>
        public OpenPlatformOptions Platform { get; set; }

        /// <summary>
        /// 获取或设置开放平台的OpenID。
        /// </summary>
        public string OpenID { get; set; }

        /// <summary>
        /// 获取或设置开放平台的UnionID。
        /// </summary>
        public string UnionID { get; set; }

        /// <summary>
        /// 获取或设置用户ID。
        /// </summary>
        public Guid UserID { get; set; }
    }

    /// <summary>
    /// 表示开放平台的项。
    /// </summary>
    public enum OpenPlatformOptions
    {
        WeChat = 1,
        QQ = 2,
        Weibo = 4
    }
}
