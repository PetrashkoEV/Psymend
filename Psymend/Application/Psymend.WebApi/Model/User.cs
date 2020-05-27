using System.Text.Json.Serialization;

namespace Psymend.WebApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }

    public static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}