using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework.EntityTypeConfigurations
{
    public interface ITypeConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
