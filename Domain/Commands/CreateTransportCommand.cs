using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateTransportCommand(string name, short engineSize, short passengersCount, int price, short? modelId, short availableLevel) : IRequest<TransportDTO>;
}