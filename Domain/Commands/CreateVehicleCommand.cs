using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateVehicleCommand(int userId, int transportId) : IRequest<VehicleDTO>;
}