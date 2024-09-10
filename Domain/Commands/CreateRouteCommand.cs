using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateRouteCommand(string name, short aCityId, short bCityId, short timeDelay) : IRequest<RouteDTO>;
}
