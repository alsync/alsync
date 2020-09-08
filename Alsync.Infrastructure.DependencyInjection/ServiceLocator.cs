using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Alsync.Infrastructure.DependencyInjection
{
    public sealed class ServiceLocator
    {
        public static ServiceLocator Instance { get; } = new ServiceLocator();

        private IServiceProvider serviceProvider;

        private ServiceLocator() { }

        public void ConfirgureServiceProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return this.serviceProvider.GetRequiredService<T>();
        }

        public IEnumerable<T> GetServices<T>()
        {
            return this.serviceProvider.GetServices<T>();
        }
    }
}
