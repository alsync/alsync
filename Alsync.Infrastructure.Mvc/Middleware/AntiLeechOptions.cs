using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Mvc.Middleware
{
    /// <summary>
    /// 表示防盗链的配置项。
    /// </summary>
    public class AntiLeechOptions
    {
        public AntiLeechOptions()
        {
            this.Domains = new List<string>();
        }

        /// <summary>
        /// 获取或设置允许访问的域名列表。
        /// </summary>
        public List<string> Domains { get; set; }

        /// <summary>
        /// 获取或设置触发防盗链的默认显示图片路径。
        /// </summary>
        public string DefaultImagePath { get; set; }
    }
}
