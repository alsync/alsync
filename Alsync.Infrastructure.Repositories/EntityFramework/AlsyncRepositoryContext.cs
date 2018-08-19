using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Alsync.Infrastructure.Repositories.EntityFramework
{
    public class AlsyncRepositoryContext : EntityFrameworkRepositoryContext
    {
        private readonly DbContext context;

        public override DbContext Context => context;

        public AlsyncRepositoryContext(AlsyncDbContext context) => this.context = context;
    }
}
