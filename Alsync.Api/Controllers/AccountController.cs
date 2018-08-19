using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Alsync.IApplication;
using Alsync.Infrastructure.Results;

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

        [HttpPost]
        public HttpResult Post()
        {
            this._userService.Login("abc", "abc");
            return new HttpResult
            {
                Result = true
            };
        }

        [HttpGet]
        public HttpResult Get()
        {
            this._userService.Login("abc", "abc");
            return new HttpResult
            {
                Result = true
            };
        }
    }
}