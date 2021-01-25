using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events.Handlers
{
    public interface IDomainEventHandler<TDomainEvent> : IEventHandler<TDomainEvent>
          where TDomainEvent : class, IDomainEvent
    {
    }
}
