using AutoMapper;
using Common;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;

namespace Domain.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RouteDTO> CreateRouteAsync(string name, short aCityId, short bCityId, short timeDelay)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(aCityId);
            if (city == null)
            {
                throw new DriveException("Unknown city A id");
            }

            city = await _unitOfWork.Cities.GetByIdAsync(bCityId);
            if (city == null)
            {
                throw new DriveException("Unknown city B id");
            }

            var route = new Route
            {
                Name = name,
                ACityId = aCityId,
                BCityId = bCityId,
                TimeDelay = timeDelay
            };

            _unitOfWork.Routes.Add(route);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<Route, RouteDTO>(route);
        }

        public async Task<RouteDTO?> GetRouteAsync(int id)
        {
            var route = await _unitOfWork.Routes.GetByIdAsync(id);
            if (route != null)
            {
                return _mapper.Map<Route, RouteDTO>(route);
            }

            return null;
        }
    }
}
