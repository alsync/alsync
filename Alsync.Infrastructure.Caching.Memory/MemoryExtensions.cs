using Alsync.Infrastructure.Caching;
using Alsync.Infrastructure.Caching.Memory;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MemoryExtensions
    {
        public static CacheBuilder AddMemory(this CacheBuilder builder, Action<MemoryDistributedCacheOptions> setupAction)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            var services = builder.Services;
            services.Configure(setupAction);
            services.AddSingleton<ICache, Memory>();

            return builder;
        }
    }
}
