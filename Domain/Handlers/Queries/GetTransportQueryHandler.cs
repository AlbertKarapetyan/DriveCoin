using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetTransportQueryHandler : IRequestHandler<GetTransportQuery, TransportDTO?>
    {
        private readonly ITransportService _transportService;

        public GetTransportQueryHandler(ITransportService transportService)
        {
            _transportService = transportService;
        }

        public async Task<TransportDTO?> Handle(GetTransportQuery request, CancellationToken cancellationToken)
        {
            return await _transportService.GetTransportAsync(request.id);
        }
    }
}
