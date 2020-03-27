using Alsync.Infrastructure.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure
{
    public class CacheHelper
    {
        public bool Set(string key, string value, TimeSpan? expiry = null)
        {
            var flag = RedisClient.Instance.SetString(key, value, expiry);
            return flag;
        }

        public string Get(string key)
        {
            var result = RedisClient.Instance.GetString(key);
            return result;
        }
    }
}
