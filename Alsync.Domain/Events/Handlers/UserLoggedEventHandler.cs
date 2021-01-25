using Alsync.Domain.Models;
using Alsync.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Events.Handlers
{
    public class UserLoggedEventHandler : IDomainEventHandler<UserLoggedEvent>
    {
        public UserLoggedEventHandler()
        {
        }

        public void Handle(UserLoggedEvent evnt)
        {
            var account = evnt.Source as UserAccount;
        }
    }
}
