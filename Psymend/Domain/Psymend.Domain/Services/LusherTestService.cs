using System;
using System.Collections.Generic;
using System.Linq;
using Psymend.Domain.Core.Services;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class LusherTestService : ILusherTestService
    {
        private readonly ILusherTestRepository _lusherTestRepository;

        public LusherTestService(ILusherTestRepository lusherTestRepository)
        {
            _lusherTestRepository = lusherTestRepository;
        }

        public void ProcessData(List<List<int>> colorSet, int userId)
        {
            var entity = new LusherTestEntity
            {
                UserId = userId,
                CreateDate = DateTime.UtcNow,
                LusherChoices = colorSet.Select((set, setIndex) => 
                        new LusherChoiceEntity
                        {
                            ChoiceNumber = setIndex,
                            LusherChoices = set.Select((color, index) => 
                                new LusherChoiceColorEntity
                                {
                                    Color = color,
                                    Position = index
                                })
                                .ToList()
                        })
                    .ToList()
            };
            _lusherTestRepository.SaveLusherTest(entity);
        }
    }
}