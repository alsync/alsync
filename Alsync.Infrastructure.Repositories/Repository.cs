using Alsync.Domain;
using Alsync.Domain.Repositories;
using Alsync.Infrastructure.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alsync.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class, IAggregateRoot
    {
        public IRepositoryContext Context { get; set; }

        public Repository(IRepositoryContext context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this.Context = context as IEntityFrameworkRepositoryContext;
        }

        public void Create(TEntity entity)
        {
            this.Context.Create(entity);
        }

        public void Remove(TEntity entity)
        {
            this.Context.Remove(entity);
        }

        public void Modify(TEntity entity)
        {
            this.Context.Modify(entity);
        }

        public TEntity Find<TKey>(TKey id)
        {
            return this.Context.Find<TEntity, TKey>(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return this.Context.Queryable<TEntity>();
        }
    }
}
