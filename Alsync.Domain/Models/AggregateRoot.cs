using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示聚合根类型的基类。
    /// </summary>
    public class AggregateRoot : Entity, IAggregateRoot
    {
        /// <summary>
        /// 获取或设置行版本。
        /// </summary>
        public byte[] RowVersion { get; protected set; }
    }
}
