using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, CityDTO?>
    {
        private readonly ICityService _cityService;

        public GetCityQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<CityDTO?> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            return await _cityService.GetCityAsync(request.id);
        }
    }
}
