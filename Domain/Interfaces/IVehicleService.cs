using DTO;

namespace Domain.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleDTO?> GetVehicleAsync(int id);
        Task<VehicleDTO> CreateVehicleAsync(int userId, int transportId);
    }
}
