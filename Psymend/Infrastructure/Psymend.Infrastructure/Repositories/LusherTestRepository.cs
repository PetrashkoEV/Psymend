using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class LusherTestRepository : BaseSqlRepository<PsymendBaseSqlContext>, ILusherTestRepository
    {
        public LusherTestRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public void SaveLusherTest(LusherTestEntity entity)
        {
            Context.LusherTests.Add(entity);
            Context.SaveChanges();
        }
    }
}