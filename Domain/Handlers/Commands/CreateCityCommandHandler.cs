using Domain.Commands;
using Domain.Interfaces;
using DTO;
using MediatR;

namespace Domain.Handlers.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CityDTO>
    {
        private readonly ICityService _cityService;

        public CreateCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<CityDTO> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            return await _cityService.CreateCityAsync(request.name, request.mapId, request.availableLevel);
        }
    }
}
