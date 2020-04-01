using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alsync.Infrastructure.Caching.Redis
{
    public class Redis : ICache
    {
        private readonly RedisCache redisCache;

        public Redis(IOptions<RedisCacheOptions> options)
        {
            this.redisCache = new RedisCache(options.Value);
        }

        public string Get(string key)
        {
            var bytes = this.redisCache.Get(key);
            if (bytes == null || bytes.Length == 0)
                return null;

            var value = Encoding.UTF8.GetString(bytes);
            return value;
        }

        public async Task<string> GetAsync(string key)
        {
            var bytes = await this.redisCache.GetAsync(key);
            if (bytes == null || bytes.Length == 0)
                return null;

            var value = Encoding.UTF8.GetString(bytes);
            return value;
        }

        public void Remove(string key)
        {
            this.redisCache.Remove(key);
        }

        public void Set(string key, string value, TimeSpan? expiry = null)
        {
            var expire = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiry };
            this.redisCache.Set(key, Encoding.UTF8.GetBytes(value), expire);
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            var expire = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiry };
            await this.redisCache.SetAsync(key, Encoding.UTF8.GetBytes(value), expire);
        }
    }
}
