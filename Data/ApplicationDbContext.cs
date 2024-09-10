using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void ConfigureConventions(
                ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(28, 10);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<City>()
                .HasOne(p => p.Map)
                .WithMany()
                .HasForeignKey(p => p.MapId);

            modelBuilder.Entity<Route>()
                .HasOne(p => p.ACity)
                .WithMany()
                .HasForeignKey(p => p.ACityId);

            modelBuilder.Entity<Route>()
                .HasOne(p => p.BCity)
                .WithMany()
                .HasForeignKey(p => p.BCityId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(p => p.Transport)
                .WithMany()
                .HasForeignKey(p => p.TransportId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(p => p.Route)
                .WithMany()
                .HasForeignKey(p => p.RouteId);
        }

        public int Commit()
        {
            return base.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
