using System;
using System.Collections.Generic;
using System.Linq;
using Psymend.Core.Enums;
using Psymend.Core.Models;
using Psymend.Domain.Test.Lusher.Core.Services;

namespace Psymend.Domain.Test.Lusher.Services
{
    public class TestLusherProcessor : ITestLusherProcessor
    {
        private readonly List<int> _basicColors = new List<int> { 1, 2, 3, 4 };
        private readonly List<int> _compensationColors = new List<int> { 6,7,8 };

        public LusherTestResult ProcessData(LusherTest test)
        {
            ColorComparison(test.FirstChoice, test.SecondChoice);
            return ResultsPreparation(test);
        }

        private void ColorComparison(List<LusherChoice> firstChoice, List<LusherChoice> secondChoice)
        {
            var currentGroupType = GroupType.Positive;
            var previousFirstChoiceElement = firstChoice.First();
            var previousSecondChoiceElement = secondChoice.First();
            var anxiety = false;

            for (var i = 0; i < firstChoice.Count; i++)
            {
                currentGroupType = GetGroupType(
                    firstChoice[i], 
                    secondChoice[i], 
                    previousFirstChoiceElement, 
                    previousSecondChoiceElement, 
                    currentGroupType,
                    i);

                if (anxiety || DetectingAnxiety(firstChoice[i], secondChoice[i], i))
                {
                    anxiety = true;
                    currentGroupType = GroupType.Negative;
                    secondChoice[i].Anxiety = true;
                }

                secondChoice[i].Group = currentGroupType;

                SetIntensity(secondChoice[i], i);

                previousFirstChoiceElement = firstChoice[i];
                previousSecondChoiceElement = secondChoice[i];
            }
        }

        private GroupType GetGroupType(
            LusherChoice firstChoiceElement, 
            LusherChoice secondChoiceElement, 
            LusherChoice previousFirstChoiceElement, 
            LusherChoice previousSecondChoiceElement, 
            GroupType currentGroupType,
            int index)
        {

            if (currentGroupType == GroupType.Positive)
            {
                if (firstChoiceElement.Color == secondChoiceElement.Color)
                {
                    return GroupType.Positive;
                }

                return GroupType.Spontaneous;
            }
            else if (currentGroupType == GroupType.Spontaneous)
            {
                if (secondChoiceElement.Color == previousFirstChoiceElement.Color &&
                    firstChoiceElement.Color == previousSecondChoiceElement.Color)
                {
                    return GroupType.Spontaneous;
                }

                //previousSecondChoiceElement.Group = GroupType.Neutral; // overwrite the previous value
                return GroupType.Neutral;
            }
            else if (currentGroupType == GroupType.Neutral)
            {
                if (secondChoiceElement.Color == previousFirstChoiceElement.Color &&
                    firstChoiceElement.Color == previousSecondChoiceElement.Color && 
                    index == 7)
                {
                    previousSecondChoiceElement.Group = GroupType.Negative; // overwrite the previous value
                    return GroupType.Negative;
                }
            }

            if (index == 8)
            {
                return GroupType.Negative;
            }

            return currentGroupType;
        }

        private bool DetectingAnxiety(
            LusherChoice firstChoiceElement,
            LusherChoice secondChoiceElement,
            int index)
        {
            return index >= 5 && 
                   (_basicColors.Contains(firstChoiceElement.Color) || _basicColors.Contains(secondChoiceElement.Color));
        }

        private void SetIntensity(LusherChoice choice, int index)
        {
            if (index > 4 && _basicColors.Contains(choice.Color))
            {
                choice.Intensity = index - 4;
            }
            else if (index < 3 && _compensationColors.Contains(choice.Color))
            {
                choice.Intensity = Math.Abs(3 - index);
            }
            else
            {
                choice.Intensity = 0;
            }
        }

        private static LusherTestResult ResultsPreparation(LusherTest test)
        {
            var result = new LusherTestResult()
            {
                Intensity = test.FirstChoice.Sum(item => item.Intensity) + test.SecondChoice.Sum(item => item.Intensity),
                ColorSet = new List<List<LusherChoice>>
                {
                    test.FirstChoice,
                    test.SecondChoice
                },
                Groups = new List<LusherResultGroup>()
            };

            for (var i = 0; i < test.FirstChoice.Count; i++)
            {
                result.Groups.Add(new LusherResultGroup
                {
                    FirstColor = test.FirstChoice[i].Color,
                    SecondAnxiety = test.SecondChoice[i].Anxiety,
                    SecondGroup = test.SecondChoice[i].Group,
                    SecondColor = test.SecondChoice[i].Color,
                    Position = i
                });
            }

            return result;
        }
    }
}