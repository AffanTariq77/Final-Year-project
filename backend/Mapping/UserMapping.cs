using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureAdorn.API.Models;
namespace AdventureAdorn.API.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Age).HasMaxLength(100);
            builder.Property(u => u.Gender).HasMaxLength(100);
            builder.Property(u => u.Discription).HasMaxLength(100);
            builder.Property(u => u.Type).HasMaxLength(100);
            builder.Property(u => u.Contact).HasMaxLength(100);
            builder.Property(u => u.ProfilePicture).HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(256);
            builder.Property(u => u.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(true);
            builder.HasIndex(u => u.Email).IsUnique();
    }
    }

}
