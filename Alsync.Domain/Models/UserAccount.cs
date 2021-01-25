using Alsync.Domain.Events;
using Alsync.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class UserAccount : AggregateRoot
    {
        public UserAccount(string account, string password)
        {
            this.Account = account;
            this.Password = password;

            this.CreateDate = DateTimeOffset.Now;
        }

        public string Account { get; private set; }

        public string Password { get; private set; }

        public int LoginCount { get; private set; }

        public DateTimeOffset? LastLoginDate { get; private set; }

        public DateTimeOffset CreateDate { get; private set; }

        public virtual User User { get; set; }

        public void Login(string account, string password)
        {
            if (this.Account != account || this.Password != password)
                throw new ValidationException("账号或者密码错误。");

            this.LoginCount += 1;
            this.LastLoginDate = DateTime.Now;

            DomainEventBus.Publish(new UserLoggedEvent(this) { Account = account });
        }
    }
}
