using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychoBioResultEntity
    {
        public int PsychobioResultId { get; set; }

        public int DisadaptationId { get; set; }
        public int AnxietyId { get; set; }
        public int FrustrationId { get; set; }
        public int GeneralConditionId { get; set; }
        public int GeneralConditionValue { get; set; }

        public List<PsychoBioTestEntity> PsychobioTests { get; set; }

        public PsychobioTestSummaryDescriptionEntity Disadaptation { get; set; }
        public PsychobioTestSummaryDescriptionEntity Anxiety { get; set; }
        public PsychobioTestSummaryDescriptionEntity Frustration { get; set; }
        public PsychobioTestSummaryDescriptionEntity GeneralCondition { get; set; }
    }
}