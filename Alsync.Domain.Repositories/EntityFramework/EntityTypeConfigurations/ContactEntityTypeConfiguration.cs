using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class ContactEntityTypeConfiguration : EntityTypeConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(m => m.Label)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(m => m.Phone)
                .HasMaxLength(20)
                .IsRequired();

            //builder.HasOne(m => m.Profile)
            //    .WithMany(m => m.Contacts)
            //    .HasForeignKey(m => m.ProfileID);

            base.Configure(builder);
        }
    }
}
