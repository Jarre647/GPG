using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Repository.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task<int> CommitAsync();

        int Commit();

        bool AutoDetectChanges { get; set; }

        bool CheckConnection();
    }
}
