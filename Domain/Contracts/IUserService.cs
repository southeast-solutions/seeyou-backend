using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Request.UserOperations;

namespace Domain.Contracts
{
    public interface IUserService
    {
        public List<UserEntity> GetAll();

        public Task Add(UserEntityDto entityDto);

        public Task Verify(VerifyUserRequest request);
    }
}
