using Alsync.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
