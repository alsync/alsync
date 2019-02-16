using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    /// <summary>
    /// 表示币值的值对象。
    /// </summary>
    public class MonetaryValue
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


        #region Public Methods

        /// <summary>
        /// 确定此实例是否与另一个指定的 <see cref="MonetaryValue"/> 对象具有相同的值。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = obj as MonetaryValue;
            if (other == null)
                return false;
            return this.Amount.Equals(other.Amount) &&
                this.Currency.Equals(other.Currency);
        }

        /// <summary>
        /// 返回 <see cref="MonetaryValue"/> 的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Amount.GetHashCode() ^
                this.Currency.GetHashCode();
        }

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
