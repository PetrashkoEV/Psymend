using System.Linq;
using Psymend.Core.Enums;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class PsychoBioTestSummaryDescriptionRepository : BaseSqlRepository<PsymendBaseSqlContext>, IPsychoBioTestSummaryDescriptionRepository
    {
        public PsychoBioTestSummaryDescriptionRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public PsychobioTestSummaryDescriptionEntity GetDescription(PsychoBioTestSummaryDescriptionType type, int value)
        {
            return Context
                .PsychoBioTestSummaryDescriptions
                .FirstOrDefault(item => item.Value == value && string.Equals(type.ToString(), item.Type));
        }
    }
}