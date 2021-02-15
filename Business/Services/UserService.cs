using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoDbRepository<UserEntity> userRepository;

        public UserService(IMongoDbRepository<UserEntity> userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserEntity> GetAll()
        {
            return userRepository.AsQueryable().ToList();
        }

        public async Task Add([FromBody] UserEntityDto entityDto)
        {
            await userRepository.Insert(entityDto.ToModel());
        }
    }
}
