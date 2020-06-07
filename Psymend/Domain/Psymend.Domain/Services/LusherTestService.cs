using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Psymend.Core.Enums;
using Psymend.Core.Models;
using Psymend.Domain.Core.Services;
using Psymend.Domain.Test.Lusher.Core.Services;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class LusherTestService : ILusherTestService
    {
        private readonly ITestLusherProcessor _processor;
        private readonly ILusherTestRepository _lusherTestRepository;

        public LusherTestService(
            ITestLusherProcessor processor,
            ILusherTestRepository lusherTestRepository)
        {
            _processor = processor;
            _lusherTestRepository = lusherTestRepository;
        }

        public void ProcessData(List<List<int>> colorSet, int userId)
        {
            var domainModel = new LusherTest
            {
                FirstChoice = colorSet.First().Select(item => new LusherChoice { Color = item }).ToList(),
                SecondChoice = colorSet.Skip(1).First().Select(item => new LusherChoice { Color = item }).ToList()
            };

            _processor.ProcessData(domainModel);

            foreach (var choice  in domainModel.FirstChoice)
            {
                Debug.Write(choice.Intensity + " | ");
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.FirstChoice)
            {
                var str = " ";
                if (choice.Anxiety)
                {
                    str = "A";
                }
                Debug.Write(str + " | ");
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.FirstChoice)
            {
                Debug.Write(choice.Color + " | ");
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.SecondChoice)
            {
                Debug.Write(choice.Color + " | ");
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.SecondChoice)
            {
                switch (choice.Group)
                {
                    case GroupType.Positive:
                        Debug.Write( "+ | ");
                        break;
                    case GroupType.Spontaneous:
                        Debug.Write("x | ");
                        break;
                    case GroupType.Neutral:
                        Debug.Write("= | ");
                        break;
                    default:
                        Debug.Write("- | ");
                        break;
                }
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.SecondChoice)
            {
                var str = " ";
                if (choice.Anxiety)
                {
                    str = "A";
                }
                Debug.Write(str + " | ");
            }
            Debug.WriteLine("");
            foreach (var choice in domainModel.SecondChoice)
            {
                Debug.Write(choice.Intensity + " | ");
            }
            Debug.WriteLine("");

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
            //_lusherTestRepository.SaveLusherTest(entity);
        }
    }
}