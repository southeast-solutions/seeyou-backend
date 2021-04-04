using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Request.Experiences;
using Domain.Response.Experiences;

namespace Business.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMongoDbRepository<ExperienceEntity> experienceRepository;

        public ExperienceService(IMongoDbRepository<ExperienceEntity> experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }

        public async Task<GetExperiencesByUserIdResponse> GetByUserId(GetExperiencesByUserIdRequest request)
        {
            var experiences = await experienceRepository.FilterBy(experience => experience.UserId == request.UserId);

            return new GetExperiencesByUserIdResponse()
            {
                Experiences = experiences
            };
        }

        public async Task<GetExperiencesByLocationResponse> GetByLocation(GetExperiencesByLocationRequest getExperiencesByLocationRequest)
        {
            var experiences = await experienceRepository.FilterBy(experience => experience.Country == getExperiencesByLocationRequest.Country);

            return new GetExperiencesByLocationResponse()
            {
                Experiences = experiences
            };
        }

        public async Task Add(AddExperienceRequest addExperienceRequest, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var experience = addExperienceRequest.Experience;
                experience.UserId = id;

                await experienceRepository.Insert(experience);
            }
            else
            {
                throw new InvalidInputException();
            }
        }

        public async Task Update(UpdateExperienceRequest updateExperienceRequest, string userId)
        {
            var experience = await experienceRepository.FindById(updateExperienceRequest.Experience.Id);
            if (experience.UserId == userId)
            {
                await experienceRepository.Update(updateExperienceRequest.Experience);
            }
            else
            {
                throw new UnauthorizedUserException();
            }
        }

        public async Task Delete(DeleteExperienceRequest deleteExperienceRequest, string userId)
        {
            var experience = await experienceRepository.FindById(deleteExperienceRequest.Id);
            if (experience.UserId == userId)
            {
                await experienceRepository.Delete(experience => experience.Id == deleteExperienceRequest.Id);
            }
            else
            {
                throw new UnauthorizedUserException();
            }
        }
    }
}
