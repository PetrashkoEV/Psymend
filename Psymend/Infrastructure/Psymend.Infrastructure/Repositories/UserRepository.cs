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

        public UserEntity GetUserByIdAndPassword(string userName, string password)
        {
            return Context.Users
                .Include(x => x.Password)
                .FirstOrDefault(item => 
                    item.UserName.Equals(userName) && 
                    item.Password.Any(p => p.Password.Equals(password)) && 
                    item.Active);
        }
    }
}