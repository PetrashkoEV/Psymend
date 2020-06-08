using Psymend.Infrastructure.Core.Entities.LusherTest;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface ILusherTestRepository
    {
        void SaveLusherTest(LusherTestEntity entity);

        LusherTestEntity GetTestResult(int testId, int userId);
    }
}