using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class UserProfileEntityTypeConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(p => p.Company)
                .HasMaxLength(50);

            builder.OwnsOne(p => p.FullName, t =>
            {
                t.Property(p => p.FirstName)
                    .HasColumnName(nameof(FullName.FirstName))
                    .HasMaxLength(20);
                t.Property(p => p.MiddleName)
                    .HasColumnName(nameof(FullName.MiddleName))
                    .HasMaxLength(20);
                t.Property(p => p.LastName)
                    .HasColumnName(nameof(FullName.LastName))
                    .HasMaxLength(20);
            });

            builder.HasOne(m => m.User)
                .WithOne(m => m.UserProfile)
                .HasForeignKey<UserProfile>(m => m.ID);

            base.Configure(builder);
        }
    }
}
