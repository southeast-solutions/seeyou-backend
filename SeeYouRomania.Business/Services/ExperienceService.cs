using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Domain.Request.Experiences;

namespace Business.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMongoDbRepository<ExperienceEntity> experienceRepository;

        public ExperienceService(IMongoDbRepository<ExperienceEntity> experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }

        public async Task<IEnumerable<ExperienceEntity>> GetAllAsync(GetExperiencesRequest getExperiencesRequest)
        {
            return await experienceRepository.FilterBy(experience => experience.Country == getExperiencesRequest.Country);
        }
        
        public async Task Add(AddExperienceRequest addExperienceRequest)
        {
            await experienceRepository.Insert(addExperienceRequest.Experience);
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
