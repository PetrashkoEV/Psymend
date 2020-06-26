using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class PsychoBioTestRepository : BaseSqlRepository<PsymendBaseSqlContext>, IPsychoBioTestRepository
    {
        public PsychoBioTestRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public List<PsychoBioTestQuestionEntity> GetQuestions()
        {
            return Context.PsychoBioTestQuestions
                .Include(item => item.AnswerDefinitions)
                .ToList();
        }

        public PsychoBioTestAnswerDefinitionEntity GetAnswerDefinition(int questionNumber, int answerNumber)
        {
            return Context.PsychoBioTestAnswerDefinitions
                .Include(item => item.Question)
                .FirstOrDefault(item => item.Number == answerNumber && item.Question.QuestionNumber == questionNumber);
        }

        public PsychoBioTestEntity GetTestResult(int testId, int userId)
        {
            var testEntity = Context
                .PsychoBioTests
                .Include(test => test.Tests)
                .Include(test => test.AnswerResponses)
                    .ThenInclude(answer => answer.PsychoBioTestAnswerDefinition)
                        .ThenInclude(answerDefinition => answerDefinition.Question)
                .Include(test => test.PsychoBioResult)
                .FirstOrDefault(item => item.PsychobioTestId == testId && item.Tests.FirstOrDefault().UserId == userId);

            if (testEntity == null)
                return null;

            var resultEntity = Context
                .PsychoBioResults
                .Include(item => item.Disadaptation)
                .Include(item => item.Anxiety)
                .Include(item => item.Frustration)
                .Include(item => item.GeneralCondition)
                .FirstOrDefault(item => item.PsychobioResultId == testEntity.PsychoBioResult.PsychobioResultId);

            if (resultEntity == null) 
                return testEntity;

            testEntity.PsychoBioResult.Disadaptation = resultEntity.Disadaptation;
            testEntity.PsychoBioResult.Anxiety = resultEntity.Anxiety;
            testEntity.PsychoBioResult.Frustration = resultEntity.Frustration;
            testEntity.PsychoBioResult.GeneralCondition = resultEntity.GeneralCondition;

            return testEntity;
        }
    }
}