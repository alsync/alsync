using Alsync.IApplication;
using Alsync.Infrastructure.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// 登录。
        /// </summary>
        /// <returns></returns>
        [HttpPost("signin")]
        public HttpResult SignIn()
        {
            this._userService.Login("abc", "abc");
            return new HttpResult
            {
                Result = true
            };
        }

        /// <summary>
        /// 注销登录。
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("signout")]
        public HttpResult SignOut()
        {
            this._userService.Login("abc", "abc");
            return new HttpResult
            {
                Result = true
            };
        }
    }
}