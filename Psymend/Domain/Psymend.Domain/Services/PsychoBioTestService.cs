using System;
using System.Collections.Generic;
using System.Linq;
using Psymend.Core.Enums;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Models.Enums;
using Psymend.Domain.Core.Models.PsychoBioTest;
using Psymend.Domain.Core.Services;
using Psymend.Domain.Mappers.PsychoBioTest;
using Psymend.Domain.Test.PsychoBio.Core.Models;
using Psymend.Domain.Test.PsychoBio.Core.Processor;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class PsychoBioTestService : IPsychoBioTestService
    {
        private readonly IPsychoBioTestRepository _repository;
        private readonly IPsychoBioTestProcessor _testProcessor;
        private readonly IPsychoBioTestSummaryDescriptionRepository _descriptionRepository;
        private readonly ITestRepository _testRepository;

        public PsychoBioTestService(
            IPsychoBioTestRepository repository,
            IPsychoBioTestProcessor testProcessor, 
            IPsychoBioTestSummaryDescriptionRepository descriptionRepository, 
            ITestRepository testRepository)
        {
            _repository = repository;
            _testProcessor = testProcessor;
            _descriptionRepository = descriptionRepository;
            _testRepository = testRepository;
        }

        public PsychoBioTestModel GetTestResultById(int testId, int userId)
        {
            var entity = _repository.GetTestResult(testId, userId);

            return entity?.ToDomainModel();
        }

        public PsychoBioTestModel ProcessTestData(List<PsychoBioTestAnswerResponseModel> testResponse, int userId)
        {
            var testData = testResponse.Select(item => new PsychoBioTestAnswer
            {
                QuestionNumber = item.QuestionNumber,
                Answers = item.Answers.Select(answer => answer.AnswerNumber).ToList()
            }).ToList();
            var result = _testProcessor.ProcessData(testData);

            var entity = MapEntity(result, testResponse, userId);
            _testRepository.SaveTest(entity);

            return GetTestResultById(entity.TestId, userId);
        }

        public List<PsychoBioTestQuestion> GetQuestions()
        {
            var entities = _repository.GetQuestions();

            return entities.Select(item => item.ToDomain())
                    .OrderBy(item => item.QuestionNumber)
                    .ToList();
        }

        private TestEntity MapEntity(PsychoBioTestResult result, IEnumerable<PsychoBioTestAnswerResponseModel> testResponse, int userId)
        {
            var anxiety = GetDescription(PsychoBioTestSummaryDescriptionType.Anxiety, result.Anxiety);
            var disadaptation = GetDescription(PsychoBioTestSummaryDescriptionType.Disadaptation, result.Disadaptation);
            var frustration = GetDescription(PsychoBioTestSummaryDescriptionType.Frustration, result.Frustration);
            var generalCondition = GetDescription(PsychoBioTestSummaryDescriptionType.GeneralCondition, GetLevel(result.GeneralCondition));

            var response = MapToAnswerResponses(testResponse);

            var entity = new TestEntity
            {
                UserId = userId,
                CreateDate = DateTime.UtcNow,
                TestType = TestType.PsychoBio.ToString(),
                PsychoBioTest = new PsychoBioTestEntity
                {
                    CreateDate = DateTime.UtcNow,
                    PsychoBioTestResult = new PsychoBioTestResultEntity
                    {
                        AnxietyId = anxiety.PsychobioTestSummaryDescriptionId,
                        DisadaptationId = disadaptation.PsychobioTestSummaryDescriptionId,
                        FrustrationId = frustration.PsychobioTestSummaryDescriptionId,
                        GeneralConditionId = generalCondition.PsychobioTestSummaryDescriptionId,
                        GeneralConditionValue = result.GeneralCondition
                    },
                    AnswerResponses = response
                }
            };
            return entity;
        }

        private List<PsychoBioTestAnswerResponseEntity> MapToAnswerResponses(IEnumerable<PsychoBioTestAnswerResponseModel> testResponse)
        {
            var questions = _repository.GetQuestions();
            var entites = new List<PsychoBioTestAnswerResponseEntity>();

            foreach (var response in testResponse)
            {
                var question = questions.FirstOrDefault(item => item.QuestionNumber == response.QuestionNumber);

                if (question == null)
                {
                    break;
                }

                foreach (var answer in response.Answers)
                {
                    var answerDefinition = question.AnswerDefinitions.FirstOrDefault(a => a.Number == answer.AnswerNumber);
                    var entity = new PsychoBioTestAnswerResponseEntity
                    {
                        PsychoBioTestAnswerDefinitionId = answerDefinition.PsychoBioTestAnswerDefinitionId,
                        CustomText = answer.CustomText,
                        PsychoBioTestAnswerDefinition = answerDefinition
                    };
                    entites.Add(entity);
                }
            }

            return entites;
        }

        private int GetLevel(int generalCondition)
        {
            if (generalCondition >= 7)
            {
                return 3;
            }

            if (generalCondition >= 5)
            {
                return 2;
            }

            return 1;
        }

        private PsychobioTestSummaryDescriptionEntity GetDescription(PsychoBioTestSummaryDescriptionType type, int value)
        {
            var anxiety = _descriptionRepository.GetDescription(type, value);
            if (anxiety == null)
            {
                throw new ArgumentException($"The {type} type '{value}' was not found in the database.");
            }

            return anxiety;
        }
    }
}