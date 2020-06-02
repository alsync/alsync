using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public class UserOpenPlatformRepository : EntityFrameworkRepository<UserOpenPlatform>, IUserOpenPlatformRepository
    {
        public UserOpenPlatformRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
