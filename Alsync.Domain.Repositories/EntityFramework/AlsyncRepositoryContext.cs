using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories.EntityFramework
{
    public class AlsyncRepositoryContext : EntityFrameworkRepositoryContext
    {
        private readonly DbContext context;

        public override DbContext Context => context;

        public AlsyncRepositoryContext(AlsyncDbContext context) => this.context = context;
    }
}
