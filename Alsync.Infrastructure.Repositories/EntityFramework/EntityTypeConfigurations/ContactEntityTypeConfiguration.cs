using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(m => m.ID);
            builder.Property(m => m.Label)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(m => m.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(m => m.Profile)
                .WithMany(m => m.Phones)
                .HasForeignKey(m => m.ProfileID);
        }
    }
}
