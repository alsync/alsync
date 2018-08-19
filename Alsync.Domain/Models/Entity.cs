using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示领域实体类型的基类。
    /// </summary>
    /// <typeparam name="TKey">当前领域实体的唯一标识类型。</typeparam>
    public class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public TKey ID { get; protected set; }
    }
}
