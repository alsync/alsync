using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示领域实体类型的基类。
    /// </summary>
    public class Entity : IEntity<Guid>
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public Guid ID { get; protected set; }
    }
}
