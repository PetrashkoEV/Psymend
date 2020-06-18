using System.Collections.Generic;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface IPsychoBioTestRepository
    {
        List<PsychoBioTestQuestionEntity> GetQuestions();
    }
}