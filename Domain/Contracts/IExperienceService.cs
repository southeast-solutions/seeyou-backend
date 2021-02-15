using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Contracts
{
    public interface IExperienceService
    {
        public List<ExperienceEntity> GetAll();

        public Task Add(ExperienceEntityDto entityDto);
    }
}
