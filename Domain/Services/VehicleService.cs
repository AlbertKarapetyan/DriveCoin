using AutoMapper;
using Common;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;

namespace Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> CreateVehicleAsync(int userId, int transportId)
        {
            var transport = await _unitOfWork.Transports.GetByIdAsync(transportId);
            if (transport == null)
            {
                throw new DriveException("Unknown transport id");
            }
            
            var vehicle = new Vehicle
            {
                UserId = userId,
                TransportId = transportId,
                EngineSize = transport.EngineSize,
                PassengersCount = transport.PassengersCount
            };

            _unitOfWork.Vehicles.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Vehicle, VehicleDTO>(vehicle);
        }

        public async Task<VehicleDTO?> GetVehicleAsync(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id);
            if (vehicle != null)
            {
                return _mapper.Map<Vehicle, VehicleDTO>(vehicle);
            }

            return null;
        }
    }
}
