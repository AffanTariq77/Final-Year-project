using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureAdorn.API.Models
{
    public class User
    {
        public Guid Id { get; set; }

      
        public string Username { get; set; }

        public string Email { get; set; }

        
        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
