using Psymend.Domain.Core.Models;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Domain.Mappers.PsychoBioTest
{
    public static class PsychoBioResultMapper
    {
        public static PsychoBioResultModel ToDomainModel(this PsychoBioResultEntity entity)
        {
            var model = new PsychoBioResultModel()
            {
                GeneralConditionValue = entity.GeneralConditionValue,
                Anxiety = new PsychoBioTestSummaryDescriptionModel
                {
                    Value = entity.Anxiety.Value,
                    Description = entity.Anxiety.Description
                },
                Frustration = new PsychoBioTestSummaryDescriptionModel
                {
                    Value = entity.Frustration.Value,
                    Description = entity.Frustration.Description
                },
                Disadaptation = new PsychoBioTestSummaryDescriptionModel
                {
                    Value = entity.Disadaptation.Value,
                    Description = entity.Disadaptation.Description
                },
                GeneralCondition = new PsychoBioTestSummaryDescriptionModel
                {
                    Value = entity.GeneralCondition.Value,
                    Description = entity.GeneralCondition.Description
                }
            };
            return model;
        }
    }
}