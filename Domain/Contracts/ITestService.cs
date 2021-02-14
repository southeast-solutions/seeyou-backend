using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Contracts
{
    public interface ITestService
    {
        Task Add(TestEntityDto entityDto);
    }
}