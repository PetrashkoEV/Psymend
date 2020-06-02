using Psymend.Infrastructure.Core.Entities;

namespace Psymend.Infrastructure.Core.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(UserEntity entity);

        UserEntity GetUserByEmailAndPassword(string email, string password);

        UserEntity GetUser(int userId);
    }
}