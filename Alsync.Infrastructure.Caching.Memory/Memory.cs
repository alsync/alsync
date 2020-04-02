using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Alsync.Infrastructure.Caching.Memory
{
    public class Memory : ICache
    {
        private readonly IMemoryCache memoryCache;

        public Memory(IOptions<MemoryDistributedCacheOptions> options)
        {
            this.memoryCache = new MemoryCache(options);
        }

        public string Get(string key)
        {
            return this.memoryCache.Get<string>(key);
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }
    }
}
