using Psymend.WebApi.Model;

namespace Psymend.WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}