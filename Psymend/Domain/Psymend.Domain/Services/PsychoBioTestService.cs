using System.Collections.Generic;
using System.Linq;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Services;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class PsychoBioTestService : IPsychoBioTestService
    {
        private readonly IPsychoBioTestRepository _repository;

        public PsychoBioTestService(IPsychoBioTestRepository repository)
        {
            _repository = repository;
        }

        public PsychoBioTestResultModel GetTestResultById(int testId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<PsychoBioTestQuestion> GetQuestions()
        {
            var entities = _repository.GetQuestions();

            return entities.Select(item => new PsychoBioTestQuestion
            {
                Question = item.Question,
                Position = item.Position,
                Answers = item.AnswerDefinitions.Select(answer => new PsychoBioTestAnswerDefinitionModel
                {
                    Position = answer.Position,
                    Custom = answer.Custom,
                    Text = answer.Text
                }).ToList()
            }).ToList();
        }
    }
}