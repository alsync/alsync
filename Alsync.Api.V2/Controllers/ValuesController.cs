﻿using Alsync.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api.V2.Controllers
{
    public class ValuesController : HttpController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            CacheHelper.Remove("name");

            var value = CacheHelper.Get(DateTime.Now.ToString());
            if (string.IsNullOrEmpty(value))
            {
                CacheHelper.Set(DateTime.Now.ToString(), DateTime.Now.Ticks.ToString(), TimeSpan.FromSeconds(25));
                value = CacheHelper.Get(DateTime.Now.ToString());
            }
            return new string[] { "value1", "value2", value };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
