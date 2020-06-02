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
            this.Database.EnsureCreatedAsync();
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

            var keyProperties = modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(m => m.GetProperties());

            var rowVersionProperties = keyProperties.Where(
                m => m.ClrType == typeof(byte[]) && m.Name == "RowVersion");
            foreach (var item in rowVersionProperties)
            {
                modelBuilder.Entity(item.DeclaringEntityType.Name)
                    .Property(item.Name)
                    .IsRowVersion()
                    .IsRequired();
            }

            //var dateTimeProperties = keyProperties.Where(m => m.ClrType == typeof(DateTime));
            //foreach (var item in dateTimeProperties)
            //{
            //    modelBuilder.Entity(item.DeclaringEntityType.Name)
            //        .Property(item.Name)
            //        .HasColumnType("DateTime2");
            //}

            base.OnModelCreating(modelBuilder);
        }
    }
}
