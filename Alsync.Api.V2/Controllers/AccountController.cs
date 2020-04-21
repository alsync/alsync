using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api.V2.Controllers
{
    public class AccountController : HttpController
    {
        /// <summary>
        /// 注销登录。
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpGet("signout")]
        public void SignOut()
        {
        }
    }
}