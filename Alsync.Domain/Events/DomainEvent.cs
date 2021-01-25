using Alsync.Domain.Events.Handlers;
using Alsync.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events
{
    /// <summary>
    /// 表示继承于该类的类型为领域事件。
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        public Entity Source { get; private set; }

        public DomainEvent(Entity source) => this.Source = source;

        //public static void Publish<TDomainEvent>(TDomainEvent evnt)
        //    where TDomainEvent : class, IDomainEvent
        //{
        //    var handlers = ServiceLocator.Instance.ResolveAll<IDomainEventHandler<TDomainEvent>>();
        //    foreach (var handler in handlers)
        //    {
        //        handler.Handle(evnt);
        //    }
        //}
    }
}
