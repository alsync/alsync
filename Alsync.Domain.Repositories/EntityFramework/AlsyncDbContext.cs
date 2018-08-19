using Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework
{
    public class AlsyncDbContext : DbContext
    {
        public AlsyncDbContext(DbContextOptions<AlsyncDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());


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
