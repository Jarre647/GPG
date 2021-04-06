using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLRepository.Data;
using SQLRepository.Exceptions;

namespace SQLRepository.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private readonly List<object> _repositories = new List<object>();

        private bool _disposed;

        public UnitOfWork(SqlRepositoryContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool AutoDetectChanges
        {
            get => _context.ChangeTracker.AutoDetectChangesEnabled;
            set => _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

        public bool CheckConnection()
        {
            try
            {
                _context.Database.ExecuteSqlCommand("SELECT 1");
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException as SqlException;

                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                    throw new ConflictException("Запись уже существует");
                throw;
            }
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            var repo = (IRepository<T>)_repositories.SingleOrDefault(r => r is IRepository<T>);
            if (repo == null) _repositories.Add(repo = new EntityRepository<T>(_context));

            return repo;
        }

        private void Dispose(bool isDisposing)
        {
            if (!_disposed)
                if (isDisposing)
                    _context?.Dispose();

            _disposed = true;
        }
    }
}
