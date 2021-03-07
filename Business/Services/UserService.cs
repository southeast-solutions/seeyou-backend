using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Domain.Enums;
using Domain.Request.UserOperations;
using MongoDB.Bson;

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

        public async Task Add(UserEntityDto entityDto)
        {
            var user = entityDto.ToModel();
            if (IsUserValid(user))
            {
                await userRepository.Insert(user);
            }
        }

        public async Task Verify(VerifyUserRequest request)
        {
            var user = await userRepository.FindById(new ObjectId(request.Id));
            user.Verified = true;
            await userRepository.Update(user);
        }

        private bool IsUserValid(UserEntity user)
        {
            if (!Enum.IsDefined(typeof(UserTypes), user.UserType))
            {
                return false;
            }
            switch (user.UserType)
            {
                case UserTypes.Promoter:
                {
                    return IsValidPromoterEntity((PromoterEntity)user);
                }
                case UserTypes.ContentCreator:
                {
                    return IsValidContentCreatorEntity((ContentCreatorEntity)user);
                }
                case UserTypes.Concierge:
                {
                    return IsValidConciergeEntity((ConciergeEntity)user);
                }
                case UserTypes.Tour:
                {
                    return IsValidTourEntity((TourEntity)user);
                }
                default:
                    return false;
            }
        }

        private bool IsValidPromoterEntity(PromoterEntity promoter)
        {
            return true;
        }

        private bool IsValidContentCreatorEntity(ContentCreatorEntity contentCreator)
        {
            return true;
        }

        private bool IsValidConciergeEntity(ConciergeEntity concierge)
        {
            return true;
        }

        private bool IsValidTourEntity(TourEntity tour)
        {
            return true;
        }
    }
}
