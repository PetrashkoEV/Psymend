using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioTestAnswerDefinitionEntity
    {
        public int PsychoBioTestAnswerDefinitionId { get; set; }
        public int PsychoBioQuestionId { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public bool Custom { get; set; }

        public PsychoBioTestQuestionEntity Question { get; set; }

        public List<PsychoBioTestAnswerResponseEntity> AnswerResponses { get; set; }
    }
}