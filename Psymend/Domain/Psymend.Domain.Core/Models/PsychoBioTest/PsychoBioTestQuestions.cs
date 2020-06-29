using System.Collections.Generic;

namespace Psymend.Domain.Core.Models.PsychoBioTest
{
    public class PsychoBioTestQuestion
    {
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public bool AllowMultipleSelections { get; set; }
        public List<PsychoBioTestAnswerDefinitionModel> Answers { get; set; }
    }
}