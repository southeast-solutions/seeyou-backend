using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Contracts
{
    public interface IUserService
    {
        public List<UserEntity> GetAll();

        public Task Add(UserEntityDto entityDto);
    }
}
