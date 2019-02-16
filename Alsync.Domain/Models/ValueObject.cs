using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示值对象类型的基类。
    /// </summary>
    public class ValueObject
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = obj as ValueObject;
            if (other == null)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
