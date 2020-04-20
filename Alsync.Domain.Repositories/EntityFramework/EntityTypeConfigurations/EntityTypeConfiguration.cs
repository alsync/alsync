using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public abstract class EntityTypeConfiguration<TEntity>
         : ITypeConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.ID);

            //builder.Property("RowVersion")
            //    .IsRowVersion()
            //    .IsRequired();
            //builder.Property("DateTime")
            //    .HasColumnType("DateTime2");
        }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
