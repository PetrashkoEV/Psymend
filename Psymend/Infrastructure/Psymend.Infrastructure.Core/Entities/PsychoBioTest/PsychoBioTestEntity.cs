using System;
using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioTestEntity
    {
        public int PsychobioTestId { get; set; }
        public int PsychobioResultId { get; set; }
        public DateTime CreateDate { get; set; }

        public List<TestEntity> Tests { get; set; }
        public List<PsychoBioTestAnswerResponseEntity> AnswerResponses { get; set; }
        public PsychoBioTestResultEntity PsychoBioTestResult { get; set; }
    }
}