using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateCityCommand(string name, short mapId, short availableLevel) : IRequest<CityDTO>;
}
