using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetVehicleQuery(int id) : IRequest<VehicleDTO?>;
}
