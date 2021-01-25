using Alsync.IApplication;
using System;
using System.Collections.Generic;
using System.Text;
using Alsync.Domain.Repositories;
using Alsync.Infrastructure.Exceptions;
using System.Linq;
using Alsync.Infrastructure;
using Alsync.Domain.Models;

namespace Alsync.Application
{
    public class UserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        public UserService(
            IRepositoryContext context,
            IUserRepository userRepository,
            IUserAccountRepository userAccountRepository)
            : base(context)
        {
            this._userRepository = userRepository;
            this._userAccountRepository = userAccountRepository;
        }

        public void RegisterByAccount(string account, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(account)) throw new ValidationException($"{account}不能为空");
            if (string.IsNullOrEmpty(password)) throw new ValidationException($"{password}不能为空");
            if (password.Trim() != confirmPassword.Trim()) throw new ValidationException($"{password}与{confirmPassword}不一致");

            var encryptPassword = EncryptHelper.MD5Hash(password);
            var ar = new UserAccount(account, encryptPassword);
        }

        public void Login(string account, string password)
        {
            if (string.IsNullOrEmpty(account))
                throw new ValidationException("登录账号不能为空。");
            if (string.IsNullOrEmpty(password))
                throw new ValidationException("登录密码不能为空。");

            var ar = this._userAccountRepository.FindAll()
                .FirstOrDefault(m => m.Account == account);

            var encryptPassword = EncryptHelper.MD5Hash(password);
            if (ar == null)
            {
                throw new ValidationException("登录账号不存在。");
                //ar = new Domain.Models.User(account, encryptPassword);
                //this._userRepository.Create(ar);
                //base.Context.Commit();
            }

            ar.Login(account, encryptPassword);
            this._userAccountRepository.Modify(ar);
            base.Context.Commit();
        }
    }
}
