using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework
{
    public class AlsyncRepositoryContext : EntityFrameworkRepositoryContext
    {
        public override DbContext Context { get; }

        public AlsyncRepositoryContext(AlsyncDbContext context) => this.Context = context;
    }
}
