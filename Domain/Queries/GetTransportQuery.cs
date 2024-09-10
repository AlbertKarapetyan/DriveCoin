using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetTransportQuery(int id) : IRequest<TransportDTO?>;
}
