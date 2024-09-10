using AutoMapper;
using Data;
using Data.Entities;
using Domain.Interfaces;
using DTO;
using Infrastructure.Data.Models;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                return _mapper.Map<IUser, UserDTO>(user);
            }
            return null;
        }

        public async Task<UserDTO?> GetUserByExtIdAsync(long externalId)
        {
            Expression<Func<User, bool>> predicate = user => user.ExternalId == externalId;
            var users = await _unitOfWork.Users.FindAsync(predicate);

            if (users.Count > 0)
            {
                return _mapper.Map<User, UserDTO>(users[0]!);
            }

            return null;
        }

        public async Task<UserDTO> CreateUserAsync(long externalId, string? userName, long? refId, bool isPremium)
        {
            int? refferalId = null;

            if (refId != null)
            {
                var refferal = await GetUserByExtIdAsync(refId.Value);
                if (refferal != null)
                {
                    refferalId = refferal.Id;
                } 
            }

            var user = new User
            {
                ExternalId = externalId,
                UserName = userName,
                RefId = refferalId,
                CreatedDate = DateTime.UtcNow
            };

            _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<IUser, UserDTO>(user);
        }

        /*public async Task<IUser?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }*/

        /*public Task<IQueryable<IUser>> FindUsers(Expression<Func<User, bool>> predicate)
        {
            return await _unitOfWork.Users.FindAsync(predicate);
        }*/
    }
}
