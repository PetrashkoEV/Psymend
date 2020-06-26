using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychobioTestSummaryDescriptionEntity
    {
        public int PsychobioTestSummaryDescriptionId { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        public ICollection<PsychoBioResultEntity> DisadaptationResults { get; set; }
        public ICollection<PsychoBioResultEntity> AnxietyResults { get; set; }
        public ICollection<PsychoBioResultEntity> FrustrationResults { get; set; }
        public ICollection<PsychoBioResultEntity> GeneralConditionResults { get; set; }
    }
}