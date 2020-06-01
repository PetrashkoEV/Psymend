﻿namespace Psymend.Domain.Core.Models
{
    public class AuthenticateUserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}