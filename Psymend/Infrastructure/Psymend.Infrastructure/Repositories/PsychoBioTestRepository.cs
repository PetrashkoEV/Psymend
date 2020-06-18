using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class PsychoBioTestRepository : BaseSqlRepository<PsymendBaseSqlContext>, IPsychoBioTestRepository
    {
        public PsychoBioTestRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public List<PsychoBioTestQuestionEntity> GetQuestions()
        {
            return Context.PsychoBioTestQuestions
                .Include(item => item.AnswerDefinitions)
                .ToList();
        }
    }
}