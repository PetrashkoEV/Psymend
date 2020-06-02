using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Psymend.Domain.Core.Services;
using Psymend.WebApi.Configuration.Model;
using Psymend.WebApi.Model;

namespace Psymend.WebApi.Authenticate
{
    public class AuthService : IAuthService
    {
        private readonly IAuthenticateService _service;
        private readonly AuthenticateConfigurationModel _configurationModel;
        private const int KeyLifetimeInDays = 7;

        public AuthService(IOptions<AuthenticateConfigurationModel> configurationModel, IAuthenticateService service)
        {
            _service = service;
            _configurationModel = configurationModel.Value;
        }

        public AuthenticateUser Authenticate(string email, string password)
        {
            var user = _service.GetUser(email, password);

            if (user == null)
            {
                return null;
            }

            var model = new AuthenticateUser()
            {
                Id = user.UserId,
                Password = user.Password,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Role = user.Role,
                Email = user.Email
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configurationModel.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Id.ToString()),
                    new Claim(ClaimTypes.Role, model.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(KeyLifetimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            model.Token = tokenHandler.WriteToken(token);

            return model;
        }
    }
}