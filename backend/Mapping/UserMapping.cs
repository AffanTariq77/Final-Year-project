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

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired(false);

            builder.Property(u => u.Gender)
                .IsRequired(false);

            builder.Property(u => u.Type)
                .IsRequired(false);

            builder.Property(u => u.Contact)
                .IsRequired(false);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.ProfilePicture)
                .IsRequired(false);

            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
