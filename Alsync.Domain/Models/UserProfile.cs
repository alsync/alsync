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

        public string Name { get; protected set; }

        public string Avatar { get; protected set; }

        public UserGender Gender { get; protected set; }

        public string Company { get; protected set; }

        public string Address { get; protected set; }

        /// <summary>
        /// 获取或设置行版本。
        /// </summary>
        public byte[] RowVersion { get; protected set; }

        public DateTime CreateDate => DateTime.Now;

        public virtual IList<Contact> Phones { get; protected set; }
    }

    public enum UserGender
    {
        Female = 0,
        Male = 1
    }
}
