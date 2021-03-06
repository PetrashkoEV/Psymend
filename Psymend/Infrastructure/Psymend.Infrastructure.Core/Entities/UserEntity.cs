﻿using System.Collections.Generic;

namespace Psymend.Infrastructure.Core.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }

        public List<PasswordEntity> Passwords { get; set; }
        public List<TestEntity> Tests { get; set; }
    }
}