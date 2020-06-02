using System;
using System.Collections.Generic;
using Psymend.Domain.Core.Models;
using Psymend.Domain.Core.Models.Enums;
using Psymend.Domain.Core.Services;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Repositories;

namespace Psymend.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(CreateUserModel viewModel)
        {
            var user = _userRepository.GetUserByEmailAndPassword(viewModel.Email, viewModel.Password);

            if (user != null)
            {
                throw new ArgumentException("This user already exists");
            }

            var model = new UserEntity
            {
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Password = new List<PasswordEntity>
                {
                    new PasswordEntity
                    {
                        Password = viewModel.Password,
                        GeneratedDate = DateTime.UtcNow
                    }
                },
                RoleName = viewModel.Role,
                Active = true
            };
            _userRepository.CreateUser(model);

            viewModel.Id = model.UserId;
        }

        public UserModel GetUserById(int userId)
        {
            var model = _userRepository.GetUser(userId);

            if (model == null)
            {
                return null;
            }

            return new UserModel
            {
                UserId = model.UserId,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Active = model.Active,
                Role = model.RoleName
            };
        }
    }
}