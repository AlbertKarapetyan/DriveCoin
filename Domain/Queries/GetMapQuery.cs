using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetMapQuery(short id) : IRequest<MapDTO?>;
}
