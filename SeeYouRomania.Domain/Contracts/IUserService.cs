using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Request.UserOperations;

namespace Domain.Contracts
{
    public interface IUserService
    {
        List<UserEntity> GetAll();
        Task Add(UserEntityDto entityDto, string cognitoEntityId);
        Task Verify(VerifyUserRequest request);
        Task<UserEntity> GetById(string userId);
        Task Update(string userId, UpdateUserRequest request);
        Task<UserEntity> GetByCognitoId(string cognitoUserId);
    }
}
