using System;
using System.Collections.Generic;

namespace Psymend.Domain.Core.Models.PsychoBioTest
{
    public class PsychoBioTestModel
    {
        public int PsychobioTestId { get; set; }
        public DateTime CreateDate { get; set; }

        public PsychoBioTestResultModel PsychoBioTestResult { get; set; }
        public List<PsychoBioTestAnswerResponseModel> Answers { get; set; }
    }
}