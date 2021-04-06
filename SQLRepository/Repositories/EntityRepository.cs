using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SQLRepository.Repositories
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public EntityRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return DbSet;
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = All();
            foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
            return query;
        }

        public virtual T FindById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<T> FindByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<T> Where(params Expression<Func<T, bool>>[] predicates)
        {
            var query = All();
            foreach (var predicate in predicates) query = query.Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Remove(object id)
        {
            var entity = FindById(id);
            if (entity == null) return;
            Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
