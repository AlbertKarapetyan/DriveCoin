using AutoMapper;
using DTO;
using Infrastructure.Data.Models;

namespace Domain.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IUser, UserDTO>();
            CreateMap<IMap, MapDTO>();
            CreateMap<ICity, CityDTO>();
            CreateMap<IRoute, RouteDTO>();
            CreateMap<ITransport, TransportDTO>();
            CreateMap<IVehicle, VehicleDTO>();
            CreateMap<IBalance, BalanceDTO>();
        }
    }
}
