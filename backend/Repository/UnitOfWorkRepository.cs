
using AdventureAdorn.API.Core;
using AdventureAdorn.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdorn.API.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly AdvanturAdornContext _dbContext;

        public UnitOfWorkRepository(AdvanturAdornContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbContext Context => throw new NotImplementedException();



         public IRepository<User> UserRepository => new GenericRepository<User>(_dbContext);

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_dbContext);
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
