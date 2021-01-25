using Alsync.Domain.Events.Handlers;
using Alsync.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events
{
    public class DomainEventBus
    {
        public static void Publish<TDomainEvent>(TDomainEvent evnt)
            where TDomainEvent : class, IDomainEvent
        {
            var handlers = ServiceLocator.Instance.GetServices<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(evnt);
            }
        }
    }
}
