﻿using System.Collections.Generic;

namespace Psymend.Domain.Core.Models.PsychoBioTest
{
    public class PsychoBioTestAnswerResponseModel
    {
        public int QuestionNumber { get; set; }
        public List<PsychoBioTestAnswerResultModel> Answers { get; set; }
    }
}