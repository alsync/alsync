using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public abstract void Create(TEntity entity);

        public abstract void Remove(TEntity entity);

        public abstract void Modify(TEntity entity);

        public abstract TEntity Find<TKey>(TKey id);

        public abstract IQueryable<TEntity> FindAll();
    }
}
