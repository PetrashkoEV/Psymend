using Psymend.Infrastructure.Core.Entities;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface IUserRepository
    {
        UserEntity GetUserByIdAndPassword(string userName, string password);
    }
}