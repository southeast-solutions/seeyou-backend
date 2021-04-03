using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Validators;
using Domain.Contracts;
using Domain.DTO;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Domain.Request.UserOperations;

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

        public async Task<string> Add(UserEntityDto entityDto)
        {
            var user = entityDto.ToModel();
            if (IsUserValid(user))
            {
                await userRepository.Insert(user);
                return user.Id;
            }

            throw new InvalidInputException();
        }

        public async Task UpdateVerifiedStatus(VerifyUserRequest request)
        {
            var user = await userRepository.FindById(request.Id);
            user.Verified = request.VerifiedValue;
            await userRepository.Update(user);
        }

        public async Task<UserEntity> GetById(string userId)
        {
            return await userRepository.FindById(userId);
        }
        
        public async Task Update(string userId, UpdateUserRequest request)
        {
            var user = request.User.ToModel();
            user.Id = userId;

            await userRepository.Update(user);
        }

        private bool IsUserValid(UserEntity user)
        {
            if (!Enum.IsDefined(typeof(UserTypes), user.UserType))
            {
                return false;
            }

            var userValidator = UserValidatorFactory.GetValidator(user.UserType);
            return userValidator.IsValid(user);
        }
    }
}
