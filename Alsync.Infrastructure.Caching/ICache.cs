using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alsync.Infrastructure.Caching
{
    public interface ICache
    {
        void Set(string key, string value, TimeSpan? expiry = null);

        Task SetAsync(string key, string value, TimeSpan? expiry = null);
        string Get(string key);

        Task<string> GetAsync(string key);

        //Task<T> GetAsync<T>(string key);

        void Remove(string key);
    }
}
