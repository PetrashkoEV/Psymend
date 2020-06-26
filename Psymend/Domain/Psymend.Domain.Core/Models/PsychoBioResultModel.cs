namespace Psymend.Domain.Core.Models
{
    public class PsychoBioResultModel
    {
        public PsychoBioTestSummaryDescriptionModel Disadaptation { get; set; }
        public PsychoBioTestSummaryDescriptionModel Anxiety { get; set; }
        public PsychoBioTestSummaryDescriptionModel Frustration { get; set; }
        public PsychoBioTestSummaryDescriptionModel GeneralCondition { get; set; }

        public int GeneralConditionValue { get; set; }
    }
}