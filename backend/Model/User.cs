using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureAdorn.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName {get;set;}
        public int? Age { get;set; }
        public string? Gender { get;set; }
        public string? Type { get; set; }
        public string? Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
