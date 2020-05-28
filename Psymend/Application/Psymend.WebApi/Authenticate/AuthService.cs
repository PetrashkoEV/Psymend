using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Psymend.WebApi.Configuration.Model;
using Psymend.WebApi.Model;

namespace Psymend.WebApi.Authenticate
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticateConfigurationModel _configurationModel;
        private const int KeyLifetimeInDays = 7;

        public AuthService(IOptions<AuthenticateConfigurationModel> configurationModel)
        {
            _configurationModel = configurationModel.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = new User {Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test", Role = Role.User};

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configurationModel.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(KeyLifetimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}