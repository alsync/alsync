using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events.Handlers
{
    public interface IEventHandler<in TEvent>
         where TEvent : class, IEvent
    {
        void Handle(TEvent evnt);
    }
}
