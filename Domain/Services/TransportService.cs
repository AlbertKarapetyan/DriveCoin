using AutoMapper;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;

namespace Domain.Services
{
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransportDTO> CreateTransportAsync(string name, short engineSize, short passengersCount, int price, short? modelId, short availableLevel)
        {
            var transport = new Transport
            {
                Name = name,
                EngineSize = engineSize,
                PassengersCount = passengersCount,
                Price = price,
                ModelId = modelId,
                AvailableLevel = availableLevel
            };

            _unitOfWork.Transports.Add(transport);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Transport, TransportDTO>(transport);
        }

        public async Task<TransportDTO?> GetTransportAsync(int id)
        {
            var transport = await _unitOfWork.Transports.GetByIdAsync(id);
            if (transport != null)
            {
                return _mapper.Map<Transport, TransportDTO>(transport);
            }

            return null;
        }
    }
}
