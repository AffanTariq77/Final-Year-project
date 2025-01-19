using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdorn.API.Core
{
    public class DataReadOnlyRepositoryBase<T> : IReadOnlyRepository<T> where T : class, new()
    {                                              
        private readonly AdvanturAdornContext _context;
        public DataReadOnlyRepositoryBase(AdvanturAdornContext context)
        {
            _context = context;
        }

        private async Task<T> PrivateFind(params object[] keyValues)
        {
            return await GetDbSet().FindAsync(keyValues);
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await PrivateFind(keyValues);
        }

        private DbSet<T> GetDbSet()
        {
            return _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = GetDbSet().AsQueryable();

            if (includes != null)
                query = query.IncludeMultiple(includes);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return (await FindAllAsync(predicate, includes)).FirstOrDefault();
        }
    }
}