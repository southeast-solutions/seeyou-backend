using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Business.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMongoDbRepository<ExperienceEntity> experienceRepository;

        public ExperienceService(IMongoDbRepository<ExperienceEntity> experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }

        public List<ExperienceEntity> GetAll()
        {
            return experienceRepository.AsQueryable().ToList();
        }

        public async Task Add([FromBody] ExperienceEntityDto entityDto)
        {
            await experienceRepository.Insert(entityDto.ToModel());
        }
    }
}
