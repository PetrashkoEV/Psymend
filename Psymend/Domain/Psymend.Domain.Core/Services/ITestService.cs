using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface ITestService
    {
        TestModel GetTests(int userId, string baseUrl);
    }
}