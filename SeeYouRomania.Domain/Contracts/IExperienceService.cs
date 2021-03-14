using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Request.Experiences;

namespace Domain.Contracts
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceEntity>> GetAllAsync(GetExperiencesRequest getExperiencesRequest);
        Task Add(AddExperienceRequest addExperienceRequest);
        Task Update(UpdateExperienceRequest updateExperienceRequest);
        Task Delete(DeleteExperienceRequest deleteExperienceRequest);
    }
}
