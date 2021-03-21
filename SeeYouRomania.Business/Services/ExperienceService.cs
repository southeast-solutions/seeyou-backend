using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
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
            var experience = addExperienceRequest.Experience;
            experience.UserId = id;
            
            await experienceRepository.Insert(experience);
        }

        public async Task Update(UpdateExperienceRequest updateExperienceRequest)
        {
            await experienceRepository.Update(updateExperienceRequest.Experience);
        }

        public async Task Delete(DeleteExperienceRequest deleteExperienceRequest)
        {
            await experienceRepository.Delete(experience => experience.Id == deleteExperienceRequest.Id);
        }
    }
}
