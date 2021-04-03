using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Models;
using Domain.Request.UserOperations;

namespace Domain.Contracts
{
    public interface IUserService
    {
        List<UserEntity> GetAll();
        Task<string> Add(UserEntityDto entityDto);
        Task UpdateVerifiedStatus(VerifyUserRequest request);
        Task<UserEntity> GetById(string userId);
        Task Update(string userId, UpdateUserRequest request);
    }
}
