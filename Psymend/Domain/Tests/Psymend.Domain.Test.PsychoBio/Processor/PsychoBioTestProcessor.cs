using System.Collections.Generic;
using System.Linq;
using Psymend.Domain.Test.PsychoBio.Core.Models;
using Psymend.Domain.Test.PsychoBio.Core.Processor;

namespace Psymend.Domain.Test.PsychoBio.Processor
{
    public class PsychoBioTestProcessor : IPsychoBioTestProcessor
    {
        public PsychoBioTestResult ProcessData(List<PsychoBioTestAnswer> answers)
        {
            var disadaptation = GetDisadaptationLevel(answers);
            var anxiety = GetAnxietyLevel(answers);
            var frustration = GetFrustrationLevel(answers);
            var psychotraumaticFactors = GetPsychotraumaticFactors(answers);
            var psychosomaticCondition = GetPsychosomaticCondition(answers);

            return new PsychoBioTestResult
            {
                Disadaptation = disadaptation,
                Anxiety = anxiety,
                Frustration = frustration,
                PsychotraumaticFactors = psychotraumaticFactors,
                PsychosomaticCondition = psychosomaticCondition
            };
        }

        private int GetDisadaptationLevel(IReadOnlyCollection<PsychoBioTestAnswer> answers)
        {
            var raisingFactor = answers
                .FirstOrDefault(item => item.QuestionNumber == 8)
                .Answers
                .Intersect(new List<int>{1, 3, 5})
                .Any();

            var highLevel = answers
                .Where(item => 
                    item.QuestionNumber == 5 && item.Answer == 4 || 
                    item.QuestionNumber == 6 && item.Answer == 4 ||
                    item.QuestionNumber == 11 && item.Answer == 3 ||
                    item.QuestionNumber == 13 && item.Answer == 4)
                .ToList()
                .Count;

            if (highLevel >= 3)
            {
                return 3;
            }

            var mediumLevel = answers
                .Where(item =>
                    item.QuestionNumber == 5 && item.Answer == 3 ||
                    item.QuestionNumber == 6 && item.Answer == 3 ||
                    item.QuestionNumber == 11 && item.Answer == 2 ||
                    item.QuestionNumber == 13 && (item.Answer == 2 || item.Answer == 3))
                .ToList()
                .Count;

            var level = mediumLevel >= 3 ? 2 : 1;

            if (raisingFactor)
            {
                level++;
            }

            return level;
        }

        private int GetAnxietyLevel(IReadOnlyCollection<PsychoBioTestAnswer> answers)
        {
            var raisingFactor = answers
                .FirstOrDefault(item => item.QuestionNumber == 8)
                .Answers
                .Intersect(new List<int> { 4 })
                .Any();

            var highLevel = answers
                .Where(item =>
                    item.QuestionNumber == 9 && item.Answer == 4 ||
                    item.QuestionNumber == 10 && item.Answer == 1 ||
                    item.QuestionNumber == 12 && item.Answer == 3)
                .ToList()
                .Count;

            if (highLevel >= 2)
            {
                return 3;
            }

            var mediumLevel = answers
                .Where(item =>
                    item.QuestionNumber == 9 && item.Answer == 2 ||
                    item.QuestionNumber == 10 && (item.Answer == 2 || item.Answer == 3) ||
                    item.QuestionNumber == 12 && item.Answer == 2)
                .ToList()
                .Count;

            var level = mediumLevel >= 2 ? 2 : 1;

            if (raisingFactor)
            {
                level++;
            }

            return level;
        }

        private int GetFrustrationLevel(IReadOnlyCollection<PsychoBioTestAnswer> answers)
        {
            var raisingFactor = answers
                .FirstOrDefault(item => item.QuestionNumber == 8)
                .Answers
                .Intersect(new List<int> { 2, 5 })
                .Any();

            var highLevel = answers
                .Where(item =>
                    item.QuestionNumber == 7 && item.Answer == 3 ||
                    item.QuestionNumber == 13 && (item.Answer == 3 || item.Answer == 4))
                .ToList()
                .Count;

            if (highLevel >= 2)
            {
                return 3;
            }

            var mediumLevel = answers
                .Where(item =>
                    item.QuestionNumber == 7 && item.Answer == 2 ||
                    item.QuestionNumber == 13 && (item.Answer == 2 || item.Answer == 3))
                .ToList()
                .Count;

            var level = mediumLevel >= 2 ? 2 : 1;

            if (raisingFactor)
            {
                level++;
            }

            return level;
        }

        private List<int> GetPsychotraumaticFactors(IReadOnlyCollection<PsychoBioTestAnswer> answers)
        {
            return answers
                .First(item => item.QuestionNumber == 8).Answers;
        }

        private List<int> GetPsychosomaticCondition(IReadOnlyCollection<PsychoBioTestAnswer> answers)
        {
            return answers
                .First(item => item.QuestionNumber == 4).Answers;
        }
    }
}