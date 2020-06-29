using System.Linq;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Models.PsychoBioTest;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Domain.Mappers.PsychoBioTest
{
    public static class PsychoBioTestMapper
    {
        public static PsychoBioTestModel ToDomainModel(this PsychoBioTestEntity entity)
        {
            var answers = entity.AnswerResponses
                .GroupBy(item => item.PsychoBioTestAnswerDefinition.Question.QuestionNumber)
                .Select(item => new PsychoBioTestAnswerResponseModel
                {
                    QuestionNumber = item.Key,
                    Answers = item.Select(p => p.ToDomainModel())
                        .ToList()
                })
                .ToList();

            var model = new PsychoBioTestModel()
            {
                PsychobioTestId = entity.PsychobioTestId,
                CreateDate = entity.CreateDate,
                PsychoBioTestResult = entity.PsychoBioTestResult.ToDomainModel(),
                Answers = answers
            };

            return model;
        }
    }
}