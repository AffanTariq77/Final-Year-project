using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureAdorn.API.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AdventureAdorn.API.Core.Extenstions;

namespace AdventureAdorn.API.Core
{
#pragma warning disable CS0618 // Type or member is obsolete
    public abstract class DataRepositoryBase<T, TU, TEntityKey> : IDataRepository<T>
#pragma warning restore CS0618 // Type or member is obsolete
        where TU : DbContext, new()
    where T : Entity<TEntityKey>, new()
    {
        private readonly TU _context;

        protected DataRepositoryBase(TU context)
        {
            _context = context;
        }

        public virtual EntityEntry<T> Add(T entity)
        {
            if (ValidateEntity(entity))
            {
                return GetDbSet().Add(entity);
            }

            throw new NotValidException(entity.ValidationErrorsMessage);
        }

        private async Task<T> PrivateFind(params object[] keyValues)
        {
            return await GetDbSet().FindAsync(keyValues);
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await PrivateFind(keyValues);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            var query = GetDbSet().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.CountAsync();
        }

        public async Task<decimal> SumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
        {
            var query = GetDbSet().AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);

            return await query.SumAsync(selector);
        }

        public virtual async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, bool asSplit = false, params Expression<Func<T, object>>[] includes)
        {
            var query = GetDbSet().AsQueryable();

            if (includes != null)
                query = query.IncludeMultiple(includes);

            if (asSplit)
                query = query.AsSplitQuery();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        private DbSet<T> GetDbSet()
        {
            return _context.Set<T>();
        }

        public ValueTask<EntityEntry<T>> AddAsync(T entity)
        {
            return GetDbSet().AddAsync(entity);
        }

        public Task AddRangeAsync(List<T> entity)
        {
            return GetDbSet().AddRangeAsync(entity);
        }

        public virtual async Task RemoveAsync(params object[] keyValues)
        {
            T entity = await PrivateFind(keyValues);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public virtual void Update(T entity)
        {
            if (ValidateEntity(entity))
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
                throw new NotValidException(entity.ValidationErrorsMessage);
        }

        public virtual Task UpdateAsync(T entity)
        {
            if (ValidateEntity(entity))
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return Task.CompletedTask;
            }
            else
                throw new NotValidException(entity.ValidationErrorsMessage);
        }

        public T Clone(T entity)
        {
            return _context.Entry(entity).CurrentValues.Clone().ToObject() as T;
        }

        public virtual async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = GetDbSet().AsQueryable();

            if (includes != null)
                query = query.IncludeMultiple(includes);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return (await FindAllAsync(predicate, includes)).ToList();
        }

        public virtual async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[] includeStatements)
        {
            var query = GetDbSet().AsQueryable();

            if (includeStatements != null && includeStatements.Any())
            {
                foreach (var includeStatement in includeStatements)
                {
                    query = query.Include(includeStatement);
                }
            }

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return (await FindAllAsync(predicate, includes)).FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string[] includeStatements)
        {
            return (await FindAllAsync(predicate, includeStatements)).FirstOrDefault();
        }

        public IQueryable<T> ToQuery()
        {
            return GetDbSet().AsQueryable();
        }

        public IQueryable<T> ToQuery(Expression<Func<T, bool>> predicate)
        {
            return GetDbSet().Where(predicate).AsQueryable();
        }

        public IQueryable<T> ToQuery(Expression<Func<T, bool>> predicate, string[] includeStatements)
        {
            var query = GetDbSet().AsQueryable();
            if (includeStatements != null && includeStatements.Any())
            {
                foreach (var includeStatement in includeStatements)
                {
                    query = query.Include(includeStatement);
                }
            }
            return query.Where(predicate).AsQueryable();
        }
        

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return GetDbSet().AnyAsync(predicate);
        }

        private static bool ValidateEntity(T entity)
        {
            entity.Validate();
            return entity.IsValid;
        }
    }
}