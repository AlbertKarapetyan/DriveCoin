using DTO;
using MediatR;

namespace Domain.Queries
{
    public record GetUserQuery(int id) : IRequest<UserDTO?>;
}
