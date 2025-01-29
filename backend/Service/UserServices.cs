using AdventureAdorn.API.Dto;
using AdventureAdorn.API.Models;
using AdventureAdorn.API.Repository;
using AutoMapper;

namespace AdventureAdorn.API.Service
{
    public interface IUserServices
    {
        Task<string> Login(string email, string password);
        Task<User> Signup(UserView userView);
    }

    public class UserServices : IUserServices
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public UserServices(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<User> Signup(UserView userView)
        {
            if (userView == null)
                throw new ArgumentNullException(nameof(userView));

            if (string.IsNullOrWhiteSpace(userView.Email) || string.IsNullOrWhiteSpace(userView.Password))
                throw new ArgumentException("Email and password are required");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userView.FirstName,
                LastName = userView.LastName,
                Email = userView.Email,
                Password = userView.Password,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

             await _unitOfWorkRepository.UserRepository.AddAsync(user);
             await _unitOfWorkRepository.CommitAsync();

            return user;
        }

        public async Task<string> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Email and password are required");

            var user = await _unitOfWorkRepository.UserRepository
                .FirstOrDefaultAsync( u => u.Email == email);

            if (user == null)
                throw new ArgumentException("Invalid credentials");

            if (user.Password != password)
                throw new ArgumentException("Invalid credentials");

            return "Login successful";
        }
    }
}
