using Alsync.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class User : AggregateRoot
    {
        protected User() { }

        public User(string account, string password)
        {
            this.Name = "name";
            this.UserAccount = new UserAccount(account, password);

            this.CreateDate = DateTimeOffset.Now;
        }

        public string Name { get; private set; }

        public string Avatar { get; private set; }

        public UserGender? Gender { get; private set; }

        public string Company { get; private set; }

        public string Address { get; private set; }

        public  virtual UserAccount UserAccount { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public DateTimeOffset CreateDate { get; private set; }
    }
}
