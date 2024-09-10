using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, VehicleDTO?>
    {
        private readonly IVehicleService _vehicleService;

        public GetVehicleQueryHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<VehicleDTO?> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            return await _vehicleService.GetVehicleAsync(request.id);
        }
    }
}
