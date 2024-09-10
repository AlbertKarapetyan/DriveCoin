using AutoMapper;
using Common;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;

namespace Domain.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDTO> CreateCityAsync(string name, short mapId, short availableLevel)
        {
            var map = await _unitOfWork.Maps.GetByIdAsync(mapId);
            if (map == null)
            {
                throw new DriveException("Unknown map id");
            }

            var city = new City
            {
                Name = name,
                MapId = mapId,
                AvailableLevel = availableLevel
            };

            _unitOfWork.Cities.Add(city);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<City, CityDTO>(city);
        }

        public async Task<CityDTO?> GetCityAsync(short id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city != null)
            {
                return _mapper.Map<City, CityDTO>(city);
            }

            return null;
        }
    }
}
