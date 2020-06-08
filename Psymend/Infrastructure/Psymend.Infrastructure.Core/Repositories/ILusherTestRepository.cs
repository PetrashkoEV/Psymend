using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface ILusherTestRepository
    {
        LusherTestEntity GetTestResult(int testId, int userId);
    }
}