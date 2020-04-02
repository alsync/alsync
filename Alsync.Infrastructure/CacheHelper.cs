using Alsync.Infrastructure.Caching;
using Alsync.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure
{
    public class CacheHelper
    {
        private static readonly ICache cache = ServiceLocator.Instance.GetService<ICache>();

        public static void Set(string key, string value, TimeSpan? expiry = null)
        {
            cache.SetAsync(key, value, expiry);
        }

        public static string Get(string key)
        {
            var result = cache.Get(key);
            return result;
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
