using Alsync.Domain.Models;
using Alsync.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context) { }
    }
}
