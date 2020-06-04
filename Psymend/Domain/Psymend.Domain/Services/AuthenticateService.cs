using System.Linq;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Services;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthenticateUserModel GetUser(string email, string password)
        {
            var userEntity = _userRepository.GetUserByEmailAndPassword(email, password);

            if (userEntity == null || !userEntity.Active)
            {
                return null;
            }

            return new AuthenticateUserModel
            {
                UserId = userEntity.UserId,
                Password = userEntity.Passwords.First().Password,
                FirstName = userEntity.FirstName,
                Active = userEntity.Active,
                Gender = userEntity.Gender,
                LastName = userEntity.LastName,
                PhoneNumber = userEntity.PhoneNumber,
                Email = userEntity.Email,
                Role = userEntity.RoleName
            };
        }
    }
}