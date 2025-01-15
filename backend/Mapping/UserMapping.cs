using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureAdorn.API.Models;
namespace AdventureAdorn.API.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name
            builder.ToTable("Users");

            // Primary key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd(); // For auto-generating IDs

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.FirstName)
                   .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .HasMaxLength(50);

            builder.Property(u => u.CreatedDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()"); // Default value for SQL Server

            builder.Property(u => u.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            // Indexes
            builder.HasIndex(u => u.Email)
                   .IsUnique(); // Ensures unique email addresses
        }
    }
}
