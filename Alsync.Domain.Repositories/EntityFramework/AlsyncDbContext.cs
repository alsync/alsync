using Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework
{
    public class AlsyncDbContext : DbContext
    {
        public AlsyncDbContext(DbContextOptions<AlsyncDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurationTypes = from m in Assembly.GetExecutingAssembly().GetTypes()
                                     where (m.BaseType?.IsGenericType ?? false)
                                     && m.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                                     select m;
            foreach (var type in configurationTypes)
            {
                var typeConfiguration = Activator.CreateInstance(type) as ITypeConfiguration;
                typeConfiguration.Configure(modelBuilder);
            }

            //modelBuilder.Properties<byte[]>()
            //    .Where(m => m.Name == "RowVersion")
            //    .Configure(m => m.IsRowVersion());
            //modelBuilder.Properties<DateTime>()
            //    .Configure(m =>
            //        m.HasColumnType("DateTime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
