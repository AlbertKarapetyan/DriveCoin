using Data.Entities;
using Data.Repositories;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Map> Maps { get; }
        IRepository<City> Cities { get; }
        IRepository<Route> Routes { get; }
        IRepository<Transport> Transports { get; }
        IRepository<Vehicle> Vehicles { get; }
        IRepository<Balance> Balances { get; }
        Task<int> CompleteAsync();
    }
}
