using Domain.Commands;
using Domain.Interfaces;
using DTO;
using MediatR;

namespace Domain.Handlers.Commands
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, VehicleDTO>
    {
        private readonly IVehicleService _vehicleService;

        public CreateVehicleCommandHandler(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<VehicleDTO> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _vehicleService.CreateVehicleAsync(request.userId, request.transportId);
        }
    }
}
