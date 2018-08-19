using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class UserProfileEntityTypeConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(m => m.ID);
            builder.Property(m => m.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(m => m.Address)
                .HasMaxLength(50);

            builder.HasMany(m => m.Phones)
                .WithOne(m => m.Profile)
                .HasForeignKey(m => m.ProfileID);
        }
    }
}
