using DTO;

namespace Domain.Interfaces
{
    public interface IMapService
    {
        Task<MapDTO?> GetMapAsync(short id);
        Task<MapDTO> CreateMapAsync(string name, short availableLevel);
    }
}
