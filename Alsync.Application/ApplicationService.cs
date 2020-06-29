using Alsync.Domain.Repositories;
using Alsync.IApplication;
using System;

namespace Alsync.Application
{
    public class ApplicationService : IApplicationService
    {
        /// <summary>
        /// 初始化 <c>ApplicationService</c> 类的新实例。
        /// </summary>
        /// <param name="context"></param>
        public ApplicationService(IRepositoryContext context) => this.Context = context;

        /// <summary>
        /// 获取仓储上下文。
        /// </summary>
        protected IRepositoryContext Context { get; }
    }
}
