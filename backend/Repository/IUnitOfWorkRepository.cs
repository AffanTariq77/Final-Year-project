using AdventureAdorn.API.Core;
using AdventureAdorn.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace AdventureAdorn.API.Repository
{
    public interface IUnitOfWorkRepository
    {
        DbContext Context { get; }
        IRepository<User> UserRepository { get; }
     

        [Obsolete("Stop using it and use CommitAsync instead")]
        int Commit();
        Task<int> CommitAsync();
    }
}
