using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示币值的值对象。
    /// </summary>
    public class MonetaryValue : ValueObject
    {
        #region Ctor

        /// <summary>
        /// 初始化 <see cref="MonetaryValue"/> 类的新实例。
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        public MonetaryValue(decimal amount, CurrencyType currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        #endregion


        #region Public Properties.

        /// <summary>
        /// 获取或设置货币数额。
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// 获取或设置币种。
        /// </summary>
        public CurrencyType Currency { get; private set; }

        #endregion
    }

    /// <summary>
    /// 表示货币的类型。
    /// </summary>
    public enum CurrencyType
    {
        AUD,
        CAD,
        CNY,
        EUR,
        GBP,
        JPY,
        USD
    }
}
