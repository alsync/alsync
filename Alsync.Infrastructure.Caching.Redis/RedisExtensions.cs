using Alsync.Infrastructure.Caching;
using Alsync.Infrastructure.Caching.Redis;
using Microsoft.Extensions.Caching.Redis;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RedisExtensions
    {
        public static CacheBuilder AddRedisCache(this CacheBuilder builder, Action<RedisCacheOptions> setupAction)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            var services = builder.Services;
            services.Configure(setupAction);
            services.AddSingleton<ICache, Redis>();

            //var configuration = services.BuildServiceProvider()
            //    .GetService<IConfiguration>();
            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = configuration["Redis:Configuration"];
            //    options.InstanceName = configuration["Redis:InstanceName"];
            //});

            return builder;
        }
    }
}
