using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示名称的值对象。
    /// </summary>
    public class FullName
    {
        #region Ctor

        /// <summary>
        /// 初始化 <see cref="FullName"/> 类的新实例。
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public FullName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// 初始化 <see cref="FullName"/> 类的新实例。
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        public FullName(string firstName, string middleName, string lastName)
            : this(firstName, lastName)
        {
            this.LastName = lastName;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// 获取或设置名。
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// 获取或设置中间名。
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// 获取或设置姓氏。
        /// </summary>
        public string LastName { get; private set; }

        #endregion


        #region Public Methods.

        /// <summary>
        /// 确定此实例是否与另一个指定的 <see cref="FullName"/> 对象具有相同的值。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = obj as FullName;
            if (other == null)
                return false;
            return this.FirstName.Equals(other.FirstName) &&
                this.MiddleName.Equals(other.MiddleName) &&
                this.LastName.Equals(other.LastName);
        }

        /// <summary>
        /// 返回 <see cref="FullName"/> 的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^
                this.MiddleName.GetHashCode() ^
                this.LastName.GetHashCode();
        }

        /// <summary>
        /// 返回表示当前对象的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.FirstName} {this.MiddleName}{this.LastName}";
        }

        public FullName WithMiddleInitial(string middleName)
        {
            if (middleName == null)
                throw new ArgumentNullException(nameof(middleName));
            if (middleName.Trim() == string.Empty)
                throw new ArgumentException($"{nameof(middleName)}为空");

            return new FullName(this.FirstName, middleName, this.LastName);
        }

        #endregion
    }
}
