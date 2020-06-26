using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioTestQuestionEntity
    {
        public int PsychoBioQuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public bool AllowMultipleSelections { get; set; }
        public string Question { get; set; }

        public List<PsychoBioTestAnswerDefinitionEntity> AnswerDefinitions { get; set; }
    }
}