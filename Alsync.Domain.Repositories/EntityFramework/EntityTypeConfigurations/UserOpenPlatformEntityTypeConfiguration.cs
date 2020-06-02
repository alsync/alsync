using Alsync.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public class UserOpenPlatformEntityTypeConfiguration : EntityTypeConfiguration<UserOpenPlatform>
    {
        public override void Configure(EntityTypeBuilder<UserOpenPlatform> builder)
        {
            builder.Property(m => m.Platform)
                .IsRequired();
            builder.Property(m => m.OpenID)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(m => m.UnionID)
                .HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
