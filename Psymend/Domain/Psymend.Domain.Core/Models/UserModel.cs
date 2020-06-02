﻿using Psymend.Domain.Core.Models.Enums;

namespace Psymend.Domain.Core.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
    }
}