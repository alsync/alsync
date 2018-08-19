namespace Alsync.Domain
{
    /// <summary>
    /// 表示继承于该接口的类型是领域实体类。
    /// </summary>
    /// <typeparam name="TKey">当前领域实体的唯一标识类型。</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        TKey ID { get; }
    }
}