using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class UserAccountEntityTypeConfiguration : EntityTypeConfiguration<UserAccount>
    {
        public override void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(p => p.Account)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(m => m.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(m => m.Account)
                .IsUnique();

            builder.HasOne(m => m.User)
                .WithOne(m => m.UserAccount)
                .HasForeignKey<UserAccount>(m => m.ID);

            base.Configure(builder);
        }
    }
}
