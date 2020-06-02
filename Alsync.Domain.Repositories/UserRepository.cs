using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
