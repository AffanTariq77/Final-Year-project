using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AdventureAdorn.API
{
    public class AdvanturAdornContext : DbContext
    {
        public AdvanturAdornContext(DbContextOptions<AdvanturAdornContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all IEntityTypeConfiguration mappings from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdvanturAdornContext).Assembly);
        }
    }
}
