using Alsync.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events
{
    public class UserLoggedEvent : DomainEvent
    {
        public UserLoggedEvent(Entity source)
            : base(source) { }

        public string Account { get; set; }
    }
}
