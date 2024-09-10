using AutoMapper;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;

namespace Domain.Services
{
    public class MapService : IMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MapService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MapDTO> CreateMapAsync(string name, short availableLevel)
        {
            var map = new Map
            {
                Name = name,
                AvailableLevel = availableLevel
            };

            _unitOfWork.Maps.Add(map);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Map, MapDTO>(map);
        }

        public async Task<MapDTO?> GetMapAsync(short id)
        {
            var map = await _unitOfWork.Maps.GetByIdAsync(id);
            if (map != null)
            {
                return _mapper.Map<Map, MapDTO>(map);
            }

            return null;
        }
    }
}
