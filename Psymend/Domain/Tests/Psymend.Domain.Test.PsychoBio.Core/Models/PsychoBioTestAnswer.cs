using System.Collections.Generic;
using System.Linq;

namespace Psymend.Domain.Test.PsychoBio.Core.Models
{
    public class PsychoBioTestAnswer
    {
        public int QuestionNumber { get; set; }

        public int Answer => Answers.FirstOrDefault();

        public List<int> Answers { get; set; }
    }
}