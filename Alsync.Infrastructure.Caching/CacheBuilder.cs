using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Caching
{
    public class CacheBuilder
    {
        public CacheBuilder(IServiceCollection services) => this.Services = services;

        public virtual IServiceCollection Services { get; }
    }
}
