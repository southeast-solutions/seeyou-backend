using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Domain.Enums;

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
            if (ValidateUserEntity(user))
            {
                await userRepository.Insert(user);
            }
        }

        private bool ValidateUserEntity(UserEntity user)
        {
            if (!Enum.IsDefined(typeof(UserTypes), user.UserType))
            {
                return false;
            }
            switch ((int)user.UserType)
            {
                case 1:
                {
                    return ValidatePromoterEntity((PromoterEntity)user);
                }
                case 2:
                {
                    return ValidateContentCreatorEntity((ContentCreatorEntity)user);
                }
                case 3:
                {
                    return ValidateConciergeEntity((ConciergeEntity)user);
                }
                case 4:
                {
                    return ValidateTourEntity((TourEntity)user);
                }
                default:
                    return false;
            }
        }

        private bool ValidatePromoterEntity(PromoterEntity promoter)
        {
            return true;
        }

        private bool ValidateContentCreatorEntity(ContentCreatorEntity contentCreator)
        {
            return true;
        }

        private bool ValidateConciergeEntity(ConciergeEntity concierge)
        {
            return true;
        }

        private bool ValidateTourEntity(TourEntity tour)
        {
            return true;
        }
    }
}
