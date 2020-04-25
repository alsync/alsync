using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(m => m.UserName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(m => m.Password)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(m => m.RowVersion)
                .IsRowVersion()
                .IsRequired();

            builder.OwnsOne(m => m.FullName, o =>
            {
                //o.ToTable("UserFullName");
                o.Property(p => p.FirstName)
                    .HasColumnName(nameof(FullName.FirstName))
                    .HasMaxLength(20);
                o.Property(p => p.MiddleName)
                    .HasColumnName(nameof(FullName.MiddleName))
                    .HasMaxLength(20);
                o.Property(p => p.LastName)
                    .HasColumnName(nameof(FullName.LastName))
                    .HasMaxLength(20);
            });
            builder.HasIndex(m => m.UserName)
                .IsUnique();

            base.Configure(builder);
        }
    }
}
