using DTO;

namespace Domain.Interfaces
{
    public interface ICityService
    {
        Task<CityDTO?> GetCityAsync(short id);
        Task<CityDTO> CreateCityAsync(string name, short mapId, short availableLevel);
    }
}
