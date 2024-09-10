using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetRouteQuery(int id) : IRequest<RouteDTO?>;
}
