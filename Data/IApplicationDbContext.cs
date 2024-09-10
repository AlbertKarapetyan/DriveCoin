using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Balance> Balances { get; set; }
        DbSet<Map> Maps { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Route> Routes { get; set; }
        DbSet<Transport> Transports { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int Commit();
        Task<int> CommitAsync();
    }
}
