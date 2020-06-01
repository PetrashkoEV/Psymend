using Psymend.Domain.Core.Models;

namespace Psymend.Domain.Core.Services
{
    public interface IAuthenticateService
    {
        AuthenticateUserModel GetUser(string userName, string password);
    }
}