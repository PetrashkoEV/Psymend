using System.Collections.Generic;

namespace Psymend.Domain.Core.Models
{
    public class PsychoBioTestQuestion
    {
        public int Position { get; set; }
        public string Question { get; set; }
        public List<PsychoBioTestAnswerDefinitionModel> Answers { get; set; }
    }
}