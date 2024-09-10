using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateMapCommand(string name, short availableLevel) : IRequest<MapDTO>;
}
