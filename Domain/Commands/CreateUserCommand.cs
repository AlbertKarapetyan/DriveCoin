using DTO;
using MediatR;

namespace Domain.Commands
{
    public record CreateUserCommand(long externalId, string? userName, long? refId, bool isPremium) : IRequest<UserDTO>;
}
