using System.Collections.Generic;
using System.Linq;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class TestRepository : BaseSqlRepository<PsymendBaseSqlContext>, ITestRepository
    {
        public TestRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public List<TestEntity> GetAllTests(int userId)
        {
            return Context.Tests.Where(item => item.UserId == userId).ToList();
        }

        public void SaveTest(TestEntity entity)
        {
            Context.Tests.Add(entity);
            Context.SaveChanges();
        }
    }
}