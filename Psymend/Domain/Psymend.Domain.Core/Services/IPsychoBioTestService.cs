using System.Collections.Generic;
using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface IPsychoBioTestService
    {
        PsychoBioTestResultModel GetTestResultById(int testId, int userId);

        List<PsychoBioTestQuestion> GetQuestions();
    }
}