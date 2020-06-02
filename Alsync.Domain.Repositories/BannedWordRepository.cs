using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public class BannedWordRepository : EntityFrameworkRepository<BannedWord>, IBannedWordRepository
    {
        public BannedWordRepository(IRepositoryContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 审查敏感词。
        /// </summary>
        /// <param name="words"></param>
        /// <param name="action"></param>
        public void Censor(string words, Action action)
        {
            var existsBannedWord = this.FindAll().Any(m => words.Contains(m.Words));
            if (existsBannedWord)
                action();
        }
    }
}
