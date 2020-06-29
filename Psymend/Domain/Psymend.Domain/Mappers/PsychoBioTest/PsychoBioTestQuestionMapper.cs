using System.Linq;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Models.PsychoBioTest;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;

namespace Psymend.Domain.Mappers.PsychoBioTest
{
    public static class PsychoBioTestQuestionMapper
    {
        public static PsychoBioTestQuestion ToDomain(this PsychoBioTestQuestionEntity entity)
        {
            var model = new PsychoBioTestQuestion
            {
                Question = entity.Question,
                QuestionNumber = entity.QuestionNumber,
                AllowMultipleSelections = entity.AllowMultipleSelections,
                Answers = entity.AnswerDefinitions.Select(answer =>
                        new PsychoBioTestAnswerDefinitionModel
                        {
                            Number = answer.Number,
                            Custom = answer.Custom,
                            Text = answer.Text
                        })
                    .OrderBy(q => q.Number)
                    .ToList()
            };
            return model;
        }
    }
}