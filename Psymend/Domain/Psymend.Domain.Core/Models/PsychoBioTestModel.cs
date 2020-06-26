using System;
using System.Collections.Generic;

namespace Psymend.Domain.Core.Models
{
    public class PsychoBioTestModel
    {
        public int PsychobioTestId { get; set; }
        public DateTime CreateDate { get; set; }

        public PsychoBioResultModel PsychoBioResult { get; set; }
        public List<PsychoBioTestAnswerResponseModel> Answers { get; set; }
    }
}