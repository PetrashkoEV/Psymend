﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class LusherTestRepository : BaseSqlRepository<PsymendBaseSqlContext>, ILusherTestRepository
    {
        public LusherTestRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public void SaveLusherTest(LusherTestEntity entity)
        {
            Context.LusherTests.Add(entity);
            Context.SaveChanges();
        }

        public LusherTestEntity GetTestResult(int testId, int userId)
        {
            return Context
                .LusherTests
                .Include(item => item.LusherResults)
                    .ThenInclude(t => t.LusherInterpretation)
                .FirstOrDefault(item => item.LusherTestId == testId && item.UserId == userId);
        }
    }
}