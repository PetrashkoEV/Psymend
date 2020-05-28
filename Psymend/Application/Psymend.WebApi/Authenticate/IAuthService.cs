using Psymend.WebApi.Model;

namespace Psymend.WebApi.Authenticate
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
    }
}