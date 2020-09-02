using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Alsync.Api.V1.Controllers
{
    public class ValuesController : HttpController
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Test get.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value; Host:" + Request.Host + "; ports:" + this._configuration["port"];
        }
    }
}