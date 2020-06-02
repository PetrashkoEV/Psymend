using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface IUserService
    {
        void CreateUser(CreateUserModel viewModel);

        UserModel GetUserById(int userId);
    }
}