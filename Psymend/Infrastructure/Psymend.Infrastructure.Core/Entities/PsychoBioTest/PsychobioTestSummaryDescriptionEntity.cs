using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities.PsychoBioTest
{
    public class PsychobioTestSummaryDescriptionEntity
    {
        public int PsychobioTestSummaryDescriptionId { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        public ICollection<PsychoBioTestResultEntity> DisadaptationResults { get; set; }
        public ICollection<PsychoBioTestResultEntity> AnxietyResults { get; set; }
        public ICollection<PsychoBioTestResultEntity> FrustrationResults { get; set; }
        public ICollection<PsychoBioTestResultEntity> GeneralConditionResults { get; set; }
    }
}