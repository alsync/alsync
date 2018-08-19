using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using System;
using System.Linq;

namespace Alsync.Domain.Repositories
{
    public abstract class RepositoryBase<TEntity> : Repository<TEntity>
         where TEntity : class, IAggregateRoot
    {
        public IRepositoryContext Context { get; set; }

        public RepositoryBase(IRepositoryContext context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this.Context = context as IEntityFrameworkRepositoryContext;
        }

        public override void Create(TEntity entity)
        {
            this.Context.Create(entity);
        }

        public override void Remove(TEntity entity)
        {
            this.Context.Remove(entity);
        }

        public override void Modify(TEntity entity)
        {
            this.Context.Modify(entity);
        }

        public override TEntity Find<TKey>(TKey id)
        {
            return this.Context.Find<TEntity, TKey>(id);
        }

        public override IQueryable<TEntity> FindAll()
        {
            return this.Context.Queryable<TEntity>();
        }
    }
}
