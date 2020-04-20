using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示用户信息的类。
    /// </summary>
    public class UserProfile : AggregateRoot
    {
        public UserProfile()
        {

        }

        public UserProfile(string name)
        {
            this.Name = name;
            this.CreateDate = DateTime.Now;
        }

        public string Name { get; private set; }

        public string Avatar { get; private set; }

        public UserGender Gender { get; private set; }

        public string Company { get; private set; }

        public string Address { get; private set; }

        public DateTime CreateDate { get; private set; }

        public virtual IList<Contact> Contacts { get; private set; }
    }

    public enum UserGender
    {
        Female = 0,
        Male = 1
    }
}
