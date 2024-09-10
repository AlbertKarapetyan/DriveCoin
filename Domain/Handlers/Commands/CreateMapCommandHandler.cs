using Domain.Commands;
using Domain.Interfaces;
using DTO;
using MediatR;

namespace Domain.Handlers.Commands
{
    public class CreateMapCommandHandler : IRequestHandler<CreateMapCommand, MapDTO>
    {
        private readonly IMapService _mapService;

        public CreateMapCommandHandler(IMapService mapService)
        {
            _mapService = mapService;
        }

        public async Task<MapDTO> Handle(CreateMapCommand request, CancellationToken cancellationToken)
        {
            return await _mapService.CreateMapAsync(request.name, request.availableLevel);
        }
    }
}
