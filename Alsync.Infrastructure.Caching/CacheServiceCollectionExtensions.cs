using Alsync.Infrastructure.Caching;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CacheServiceCollectionExtensions
    {
        public static CacheBuilder AddCache(this IServiceCollection services)
        {
            var builder = new CacheBuilder(services);
            return builder;
        }

        public static CacheBuilder AddCache(this IServiceCollection services, Action<CacheOptions> configureAction)
        {
            services.AddOptions();
            services.Configure(configureAction);

            return AddCache(services);
        }
    }
}
