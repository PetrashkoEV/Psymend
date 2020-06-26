using Psymend.Domain.Core.Models;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Domain.Mappers.PsychoBioTest
{
    public static class PsychoBioTestAnswerResultMapper
    {
        public static PsychoBioTestAnswerResultModel ToDomainModel(this PsychoBioTestAnswerResponseEntity entity)
        {
            var model = new PsychoBioTestAnswerResultModel
            {
                AnswerNumber = entity.PsychoBioTestAnswerDefinition.Number,
                CustomText = entity.CustomText,
                AnswerText = entity.PsychoBioTestAnswerDefinition.Text
            };
            return model;
        }
    }
}