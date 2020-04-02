using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alsync.Infrastructure.DependencyInjection
{
    public sealed class ServiceLocator
    {
        public static ServiceLocator Instance { get; } = new ServiceLocator();

        private IServiceProvider serviceProvider;
        public void ConfirgureServiceProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return this.serviceProvider.GetRequiredService<T>();
        }
    }
}
