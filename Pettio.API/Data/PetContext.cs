using Microsoft.EntityFrameworkCore;
using Pettio.API.Data.Entities;

namespace Pettio.API.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }
        public DbSet<UserAdoption> UserAdoptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                        .HasKey(uf => new { uf.UserId, uf.PetId });
        }
    }
}
