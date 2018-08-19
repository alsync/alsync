using Alsync.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class User : AggregateRoot
    {
        public User() => this.CreateDate = DateTime.Now;

        public string UserName { get; private set; }

        public string Password { get; private set; }

        /// <summary>
        /// 获取或设置行版本。
        /// </summary>
        public byte[] RowVersion { get; protected set; }

        public DateTime CreateDate { get; set; }

        public void Login(string account, string password)
        {
            if (this.UserName == account && this.Password == password)
            {
                //this.LoginCount += 1;
                //this.LastLoginDate = DateTime.Now;

                //DomainEvent.Publish<UserLoggedEvent>(new UserLoggedEvent(this)
                //{
                //    Account = account,
                //    Password = password
                //});
            }
            else
            {
                throw new ValidationException("用户名或者密码错误。");
            }
        }
    }
}
