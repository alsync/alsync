using Alsync.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class User : AggregateRoot
    {
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;

            this.CreateDate = DateTime.Now;
        }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public FullName FullName { get; private set; }

        public int LoginCount { get; private set; }

        public DateTimeOffset? LastLoginDate { get; private set; }

        public DateTimeOffset CreateDate { get; private set; }

        public void Login(string account, string password)
        {
            if (this.UserName == account && this.Password == password)
            {
                this.LoginCount += 1;
                this.LastLoginDate = DateTime.Now;

                //DomainEvent.Publish<UserLoggedEvent>(new UserLoggedEvent(this)
                //{
                //    Account = account,
                //    Password = password
                //});
            }
            else
            {
                throw new ValidationException("账号或者密码错误。");
            }
        }
    }
}
