using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioTestQuestionEntity
    {
        public int PsychoBioQuestionId { get; set; }
        public int Position { get; set; }
        public string Question { get; set; }

        public List<PsychoBioTestAnswerDefinitionEntity> AnswerDefinitions { get; set; }
    }
}