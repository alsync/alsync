﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示电话的值对象。
    /// </summary>
    public class Phone : ValueObject
    {
        #region Ctor

        /// <summary>
        /// 初始化 <see cref="Phone"/> 类的新实例。
        /// </summary>
        /// <param name="phoneType"></param>
        /// <param name="phoneNumber"></param>
        public Phone(PhoneType phoneType, string phoneNumber)
        {
            this.PhoneType = phoneType;
            this.PhoneNumber = phoneNumber;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// 获取或设置电话类型。
        /// </summary>
        public PhoneType PhoneType { get; private set; }

        /// <summary>
        /// 获取或设置电话号码。
        /// </summary>
        public string PhoneNumber { get; set; }

        #endregion
    }

    /// <summary>
    /// 表示电话的类型。
    /// </summary>
    public enum PhoneType
    {
        /// <summary>
        /// 指定电话类型为家庭电话。
        /// </summary>
        Home,
        /// <summary>
        /// 指定电话类型为手机。
        /// </summary>
        Mobile,
        /// <summary>
        /// 指定电话类型为工作电话。
        /// </summary>
        Work,
        /// <summary>
        /// 指定电话类型为其它。
        /// </summary>
        Other
    }
}
