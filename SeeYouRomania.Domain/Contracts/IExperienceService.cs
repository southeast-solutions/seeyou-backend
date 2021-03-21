using System.Threading.Tasks;
using Domain.Request.Experiences;
using Domain.Response.Experiences;

namespace Domain.Contracts
{
    public interface IExperienceService
    {
        Task<GetExperiencesByUserIdResponse> GetByUserId(GetExperiencesByUserIdRequest request);
        Task<GetExperiencesByLocationResponse> GetByLocation(GetExperiencesByLocationRequest getExperiencesByLocationRequest);
        Task Add(AddExperienceRequest addExperienceRequest, string id);
        Task Update(UpdateExperienceRequest updateExperienceRequest);
        Task Delete(DeleteExperienceRequest deleteExperienceRequest);
    }
}
