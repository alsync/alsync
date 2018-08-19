using Alsync.IApplication;
using System;
using System.Collections.Generic;
using System.Text;
using Alsync.Domain.Repositories;
using Alsync.Infrastructure.Exceptions;
using System.Linq;

namespace Alsync.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IRepositoryContext context,
            IUserRepository userRepository)
            : base(context)
        {
            this.userRepository = userRepository;
        }

        public void Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ValidationException("登录账号不能为空。");
            if (string.IsNullOrEmpty(password))
                throw new ValidationException("登录密码不能为空。");

            var ar = this.userRepository.FindAll()
                .FirstOrDefault(m => m.UserName == userName);
            if (ar == null)
                throw new ValidationException("登录账号不存在。");
            //var encryptPassword = HashEncrypt.MD5EncryptText(password);
            ar.Login(userName, password);
            this.userRepository.Modify(ar);
            base.Context.Commit();
        }
    }
}
