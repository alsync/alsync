using Alsync.Api.Models;
using Alsync.IApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api.Controllers
{
    /// <summary>
    /// 账户
    /// </summary>
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 初始化 <see cref="AccountController"/> 类的新实例。
        /// </summary>
        /// <param name="userService"></param>
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// 登录。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("signin")]
        public void SignIn([FromBody] SignInViewModel model)
        {
            this._userService.Login(model.Account, model.Password);
        }

        /// <summary>
        /// 注销登录。
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("signout")]
        public void SignOut()
        {
        }
    }
}