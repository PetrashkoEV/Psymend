﻿using System;
using System.Collections.Generic;
using System.Linq;
using Psymend.Core.Enums;
using Psymend.Core.Models;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Models.Enums;
using Psymend.Domain.Core.Services;
using Psymend.Domain.Test.Lusher.Core.Services;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class LusherTestService : ILusherTestService
    {
        private readonly ITestLusherProcessor _processor;
        private readonly ILusherTestRepository _lusherTestRepository;
        private readonly ITestRepository _testRepository;
        private readonly ILusherInterpretationRepository _interpretationRepository;

        public LusherTestService(
            ITestLusherProcessor processor,
            ILusherTestRepository lusherTestRepository,
            ITestRepository testRepository,
            ILusherInterpretationRepository interpretationRepository)
        {
            _processor = processor;
            _lusherTestRepository = lusherTestRepository;
            _testRepository = testRepository;
            _interpretationRepository = interpretationRepository;
        }

        public LusherTestResultModel ProcessData(List<List<int>> colorSet, int userId)
        {
            var domainModel = new LusherTest
            {
                FirstChoice = colorSet.First().Select(item => new LusherChoice { Color = item }).ToList(),
                SecondChoice = colorSet.Skip(1).First().Select(item => new LusherChoice { Color = item }).ToList()
            };

            var result = _processor.ProcessData(domainModel);

            var testId = SaveTestData(result, userId);

            return GetLusherTestResultById(testId, userId);
        }

        public LusherTestResultModel GetLusherTestResultById(int testId, int userId)
        {
            var testResult = _lusherTestRepository.GetTestResult(testId, userId);

            return new LusherTestResultModel
            {
                LusherTestId = testResult.LusherTestId,
                Intensity = testResult.Intensity,
                Interpretations = testResult.LusherResults.OrderBy(item => item.Position)
                    .Select(item => item.LusherInterpretation.Text).ToList()
            };
        }

        private int SaveTestData(LusherTestResult result, int userId)
        {
            var lusherTest = new LusherTestEntity
            {
                CreateDate = DateTime.UtcNow,
                Intensity = result.Intensity,
                LusherChoices = result.ColorSet.Select((set, setIndex) =>
                        new LusherChoiceEntity
                        {
                            ChoiceNumber = setIndex,
                            LusherChoices = set.Select((color, index) =>
                                    new LusherChoiceColorEntity
                                    {
                                        Color = color.Color,
                                        Group = color.Group.ToString(),
                                        Anxiety = color.Anxiety,
                                        Intensity = color.Intensity,
                                        Position = index
                                    })
                                .ToList()
                        })
                    .ToList(),
                LusherResults = result.Groups.Select((resultGroup, groupIndex) =>
                        new LusherResultEntity
                        {
                            FirstColor = resultGroup.FirstColor,
                            SecondColor = resultGroup.SecondColor,
                            Group = resultGroup.SecondGroup.ToString(),
                            Anxiety = resultGroup.SecondAnxiety,
                            Position = groupIndex,
                            LusherInterpretationId = GetInterpretationKey(resultGroup)
                        })
                    .ToList()
            };

            var entity = new TestEntity
            {
                CreateDate = DateTime.UtcNow,
                TestType = TestType.Lusher.ToString(),
                UserId = userId,
                LusherTest = lusherTest
            };

            _testRepository.SaveTest(entity);

            return lusherTest.LusherTestId;
        }

        private int GetInterpretationKey(LusherResultGroup result)
        {
            var key = result.SecondAnxiety ? "a" : "";

            key += $"{result.SecondGroup.ToAbbreviation()}{result.SecondColor}{result.SecondGroup.ToAbbreviation()}{result.FirstColor}";
            var entity = _interpretationRepository.GetInterpretationByKey(key);
            return entity?.LusherInterpretationId ?? _interpretationRepository.GetDefaultEntity().LusherInterpretationId;
        }
    }
}