using Alsync.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Repositories
{
    public interface IBannedWordRepository : IRepository<BannedWord>
    {
        void Censor(string words, Action action);
    }
}
