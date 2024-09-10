using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetRouteQueryHandler : IRequestHandler<GetRouteQuery, RouteDTO?>
    {
        private readonly IRouteService _routeService;

        public GetRouteQueryHandler(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task<RouteDTO?> Handle(GetRouteQuery request, CancellationToken cancellationToken)
        {
            return await _routeService.GetRouteAsync(request.id);
        }
    }
}
