using System.Text.Json.Serialization;

namespace Psymend.WebApi.Model
{
    public class AuthenticateUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }
}