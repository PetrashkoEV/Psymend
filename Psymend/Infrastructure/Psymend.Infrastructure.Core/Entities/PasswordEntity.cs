using System;

namespace Psymend.Infrastructure.Core.Entities
{
    public class PasswordEntity
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public DateTime GeneratedDate { get; set; }

        public UserEntity User { get; set; }
    }
}