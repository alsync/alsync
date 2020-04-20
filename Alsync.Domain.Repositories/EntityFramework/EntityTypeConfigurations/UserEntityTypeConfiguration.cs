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
            builder.Property("Password")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(m => m.FullName, o => o.ToTable("UserFullName"));

            base.Configure(builder);
        }
    }
}
