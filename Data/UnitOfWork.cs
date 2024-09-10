using Data.Entities;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork(IApplicationDbContext context, 
                            IRepository<User> userRepository, 
                            IRepository<Map> mapRepository, 
                            IRepository<City> cityRepository,
                            IRepository<Route> routeRepository,
                            IRepository<Transport> transportRepository,
                            IRepository<Vehicle> vehicleRepository,
                            IRepository<Balance> balanceRepository) : IUnitOfWork
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly IRepository<Map> _mapRepository = mapRepository;
        private readonly IRepository<City> _cityRepository = cityRepository;
        private readonly IRepository<Route> _routeRepository = routeRepository;
        private readonly IRepository<Transport> _transportRepository = transportRepository;
        private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;
        private readonly IRepository<Balance> _balanceRepository = balanceRepository;

        public IRepository<User> Users => _userRepository;
        public IRepository<Map> Maps => _mapRepository;
        public IRepository<City> Cities => _cityRepository;
        public IRepository<Route> Routes => _routeRepository;
        public IRepository<Transport> Transports => _transportRepository;
        public IRepository<Vehicle> Vehicles => _vehicleRepository;
        public IRepository<Balance> Balances => _balanceRepository;

        public async Task<int> CompleteAsync()
        {
            return await _context.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
