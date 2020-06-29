namespace Psymend.Domain.Core.Models.PsychoBioTest
{
    public class PsychoBioTestResultModel
    {
        public PsychoBioTestSummaryDescriptionModel Disadaptation { get; set; }
        public PsychoBioTestSummaryDescriptionModel Anxiety { get; set; }
        public PsychoBioTestSummaryDescriptionModel Frustration { get; set; }
        public PsychoBioTestSummaryDescriptionModel GeneralCondition { get; set; }

        public int GeneralConditionValue { get; set; }
    }
}