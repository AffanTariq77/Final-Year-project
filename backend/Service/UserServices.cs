using AdventureAdorn.API.Models;
using AdventureAdorn.API.Repository;
using AutoMapper;

namespace AdventureAdorn.API.Service
{
    public interface IUsersServices
    {
        Task<string> Login(Guid clientId, string form);
       
    }

    public class UsersServices : IUsersServices
    {

        public UsersServices(
            IUnitOfWorkRepository unitOfWorkRepository
            ) 
        {
        }

        public async Task<string> Login(Guid clientId, string form)
        {
            throw new NotImplementedException();
        }


       
    }
}
