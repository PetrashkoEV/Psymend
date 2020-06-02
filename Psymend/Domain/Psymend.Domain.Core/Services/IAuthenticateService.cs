using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface IAuthenticateService
    {
        AuthenticateUserModel GetUser(string email, string password);
    }
}