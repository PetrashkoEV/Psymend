﻿using System.Collections.Generic;
using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface IPsychoBioTestService
    {
        PsychoBioTestModel GetTestResultById(int testId, int userId);

        PsychoBioTestModel ProcessTestData(List<PsychoBioTestAnswerResponseModel> testResponse, int userId);

        List<PsychoBioTestQuestion> GetQuestions();
    }
}