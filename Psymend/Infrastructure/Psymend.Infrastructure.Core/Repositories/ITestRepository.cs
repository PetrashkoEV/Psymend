using System.Collections.Generic;
using Psymend.Infrastructure.Core.Entities;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface ITestRepository
    {
        List<TestEntity> GetAllTests(int userId);

        void SaveTest(TestEntity entity);
    }
}