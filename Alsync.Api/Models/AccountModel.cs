using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace Alsync.Api.Models
{
    /// <summary>
    /// 表示登录的模型对象。
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// 获取或设置登录账号。
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置登录密码。
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
