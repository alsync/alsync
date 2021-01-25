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
            builder.Property(m => m.Name)
                .HasMaxLength(20);
            builder.Property(m => m.Avatar)
                .HasMaxLength(200);
            builder.Property(m => m.Company)
                .HasMaxLength(50);
            builder.Property(m => m.Address)
                .HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
