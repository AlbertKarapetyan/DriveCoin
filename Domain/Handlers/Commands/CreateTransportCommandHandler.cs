using Domain.Commands;
using Domain.Interfaces;
using DTO;
using MediatR;

namespace Domain.Handlers.Commands
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommand, TransportDTO>
    {
        private readonly ITransportService _transportService;

        public CreateTransportCommandHandler(ITransportService transportService)
        {
            _transportService = transportService;
        }

        public async Task<TransportDTO> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            return await _transportService.CreateTransportAsync(request.name, request.engineSize, request.passengersCount, request.price, request.modelId, request.availableLevel);
        }
    }
}
