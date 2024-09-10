using DTO;

namespace Domain.Interfaces
{
    public interface IRouteService
    {
        Task<RouteDTO?> GetRouteAsync(int id);
        Task<RouteDTO> CreateRouteAsync(string name, short aCityId, short bCityId, short timeDelay);
    }
}
