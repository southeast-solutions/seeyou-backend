using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Response.Auth;
using Domain.Request.UserOperations;

namespace Domain.Contracts
{
    public interface IUserService
    {
        List<UserEntity> GetAll();
        Task Add(UserEntityDto entityDto);
        Task Verify(VerifyUserRequest request);
        Task<GetProfileInfoResponse> GetById(string userId);
    }
}
