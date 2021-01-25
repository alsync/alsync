using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public class UserAccountRepository : EntityFrameworkRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
