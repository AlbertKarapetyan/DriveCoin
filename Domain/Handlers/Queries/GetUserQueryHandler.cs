using Domain.Interfaces;
using Domain.Queries;
using DTO;
using MediatR;

namespace Domain.Handlers.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO?>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(request.id);
        }
    }
}
