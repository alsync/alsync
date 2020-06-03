using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace Alsync.Api.Models
{
    /// <summary>
    /// 表示账户相关的视图模型。
    /// </summary>
    public class AccountViewModel
    {

    }

    /// <summary>
    /// 表示登录的视图模型对象。
    /// </summary>
    public class SignInViewModel
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
