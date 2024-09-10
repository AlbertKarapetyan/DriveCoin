using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetMapQueryHandler : IRequestHandler<GetMapQuery, MapDTO?>
    {
        private readonly IMapService _mapService;

        public GetMapQueryHandler(IMapService mapService)
        {
            _mapService = mapService;
        }

        public async Task<MapDTO?> Handle(GetMapQuery request, CancellationToken cancellationToken)
        {
            return await _mapService.GetMapAsync(request.id);
        }
    }
}
