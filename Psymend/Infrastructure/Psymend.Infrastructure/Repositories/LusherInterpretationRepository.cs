using System.Linq;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class LusherInterpretationRepository : BaseSqlRepository<PsymendBaseSqlContext>, ILusherInterpretationRepository
    {
        public LusherInterpretationRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public LusherInterpretationEntity GetInterpretationByKey(string key)
        {
            return Context.LusherInterpretations.FirstOrDefault(item => item.Key.Equals(key));
        }

        public LusherInterpretationEntity GetDefaultEntity()
        {
            return Context.LusherInterpretations.FirstOrDefault(item => item.Key.Equals(" "));
        }
    }
}