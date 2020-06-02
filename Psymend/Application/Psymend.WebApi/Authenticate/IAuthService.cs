using Psymend.WebApi.Model;

namespace Psymend.WebApi.Authenticate
{
    public interface IAuthService
    {
        AuthenticateUser Authenticate(string email, string password);
    }
}