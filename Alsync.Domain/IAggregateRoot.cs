﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain
{
    /// <summary>
    /// 表示继承于该接口的类型是聚合根类型。
    /// </summary>
    public interface IAggregateRoot : IEntity<Guid>
    {
        /// <summary>
        /// 获取或设置行版本。
        /// </summary>
        byte[] RowVersion { get; }
    }
}
