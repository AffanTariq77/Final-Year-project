using System;

namespace AdventureAdorn.API.Core
{
    [Obsolete("Use IRepository<T> instead")]
    public interface IDataRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
