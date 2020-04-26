using Alsync.IApplication;
using System;
using System.Collections.Generic;
using System.Text;
using Alsync.Domain.Repositories;
using Alsync.Infrastructure.Exceptions;
using System.Linq;
using Alsync.Infrastructure;

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

        public void Login(string account, string password)
        {
            if (string.IsNullOrEmpty(account))
                throw new ValidationException("登录账号不能为空。");
            if (string.IsNullOrEmpty(password))
                throw new ValidationException("登录密码不能为空。");

            var ar = this.userRepository.FindAll()
                .FirstOrDefault(m => m.UserName == account);

            var encryptPassword = EncryptHelper.MD5Hash(password);
            if (ar == null)
            //    throw new ValidationException("登录账号不存在。");
            {
                ar = new Domain.Models.User(account, encryptPassword);
                this.userRepository.Create(ar);
                base.Context.Commit();
            }

            ar.Login(account, encryptPassword);
            this.userRepository.Modify(ar);
            base.Context.Commit();
        }
    }
}
