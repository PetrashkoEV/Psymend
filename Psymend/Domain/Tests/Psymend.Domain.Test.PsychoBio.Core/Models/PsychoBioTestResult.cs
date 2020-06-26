using System.Collections.Generic;

namespace Psymend.Domain.Test.PsychoBio.Core.Models
{
    public class PsychoBioTestResult
    {
        public int Disadaptation { get; set; }
        public int Anxiety { get; set; }
        public int Frustration { get; set; }
        public int GeneralCondition => Disadaptation + Anxiety + Frustration;

        public List<int> PsychotraumaticFactors { get; set; }
        public List<int> PsychosomaticCondition { get; set; }
    }
}