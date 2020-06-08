using System;
using System.Linq;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Services;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public TestModel GetTests(int userId, string baseUrl)
        {
            var uri = new Uri(baseUrl);
            var entity = _testRepository.GetAllTests(userId).OrderByDescending(item => item.CreateDate);
            return new TestModel
            {
                UserId = userId,
                Tests = entity.Select(item => new TestDescriptionModel
                {
                    Type = item.TestType,
                    CreateDate = item.CreateDate,
                    Uri = new Uri(uri, $"test/{item.TestType.ToLower()}/{item.LusherTestId}").AbsoluteUri
                }).ToList()
            };
        }
    }
}