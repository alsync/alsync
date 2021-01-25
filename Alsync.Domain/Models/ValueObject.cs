using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示值对象类型的基类。
    /// </summary>
    public class ValueObject
    {
        /// <summary>
        /// 确定此实例是否与另一个指定的对象具有相同的值。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!(obj is ValueObject))
                return false;
            var fields = this.GetType().GetFields();
            var objFields = obj.GetType().GetFields();
            if (fields.Length != objFields.Length)
                return false;
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                var objField = objFields[i];
                if (field.Name != objField.Name)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 返回当前对象的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.GetType()
                .GetFields()
                .Aggregate(0, (current, next) => current.GetHashCode() ^ next.GetHashCode());
        }
    }
}
