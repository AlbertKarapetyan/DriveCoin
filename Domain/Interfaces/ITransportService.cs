using DTO;

namespace Domain.Interfaces
{
    public interface ITransportService
    {
        Task<TransportDTO?> GetTransportAsync(int id);
        Task<TransportDTO> CreateTransportAsync(string name, short engineSize, short passengersCount, int price, short? modelId, short availableLevel);
    }
}
