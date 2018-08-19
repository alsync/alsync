using System;

namespace Alsync.IApplication
{
    public interface IUserService : IApplicationService
    {
        void Login(string userName, string password);
    }
}
