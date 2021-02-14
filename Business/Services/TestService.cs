using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.DTO;

namespace Business.Services
{
    public class TestService : ITestService
    {
        private readonly IMongoDbRepository<TestEntity> testRepository;

        public TestService(IMongoDbRepository<TestEntity> testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task Add(TestEntityDto entityDto)
        {
            await testRepository.Insert(entityDto.ToModel());
        }
    }
}