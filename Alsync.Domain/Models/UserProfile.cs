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
        protected UserProfile()
        {

        }

        public UserProfile(string firstName, UserGender gender, int age, string company)
        {
            this.FullName = new FullName(firstName, "");
            this.Gender = gender;
            this.Age = age;
            this.Company = company;

            this.CreateDate = DateTimeOffset.Now;
        }

        public virtual FullName FullName { get; private set; }

        public UserGender Gender { get; set; }

        public int Age { get; set; }

        public string Company { get; private set; }

        public DateTimeOffset CreateDate { get; private set; }

        public virtual User User { get; set; }

        //public virtual IList<Contact> Contacts { get; private set; }
    }

    public enum UserGender
    {
        Female = 0,
        Male = 1
    }
}
