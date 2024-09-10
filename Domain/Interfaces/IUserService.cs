using DTO;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserAsync(int id);
        Task<UserDTO?> GetUserByExtIdAsync(long externalId);
        Task<UserDTO> CreateUserAsync(long externalId, string? userName, long? refId, bool isPremium);
    }
}
