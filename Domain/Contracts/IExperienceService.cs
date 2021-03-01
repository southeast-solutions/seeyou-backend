using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Request.Experiences;

namespace Domain.Contracts
{
    public interface IExperienceService
    {
        public Task<IEnumerable<ExperienceEntity>> GetAllAsync(ExperiencesRequest experiencesRequest);

        public Task Add(AddExperienceRequest addExperienceRequest);

        public Task Update(UpdateExperienceRequest updateExperienceRequest);

        public Task Delete(DeleteExperienceRequest deleteExperienceRequest);
    }
}
