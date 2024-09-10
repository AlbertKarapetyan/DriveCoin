using Domain.Commands;
using Domain.Interfaces;
using DTO;
using MediatR;

namespace Domain.Handlers.Commands
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, RouteDTO>
    {
        private readonly IRouteService _routeService;

        public CreateRouteCommandHandler(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task<RouteDTO> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            return await _routeService.CreateRouteAsync(request.name, request.aCityId, request.bCityId, request.timeDelay);
        }
    }
}
