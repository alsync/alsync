using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alsync.Infrastructure.Caching.Redis
{
    public static class RedisCacheExtensions
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
