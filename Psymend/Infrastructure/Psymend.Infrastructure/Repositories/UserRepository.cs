using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Context;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Infrastructure.Repositories
{
    public class UserRepository : BaseSqlRepository<PsymendBaseSqlContext>, IUserRepository
    {
        public UserRepository(ISqlConnectionStringProvider connectionStringProvider)
        {
            Context = new PsymendBaseSqlContext(connectionStringProvider);
        }

        public UserEntity GetUserByEmailAndPassword(string email, string password)
        {
            return Context.Users
                .Include(x => x.Password)
                .FirstOrDefault(item => 
                    item.Email.Equals(email) && 
                    item.Password.Any(p => p.Password.Equals(password)));
        }

        public void CreateUser(UserEntity entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();
        }

        public UserEntity GetUser(int userId)
        {
            return Context.Users
                .FirstOrDefault(item => item.UserId == userId);
        }
    }
}