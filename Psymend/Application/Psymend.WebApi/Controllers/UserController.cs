using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psymend.Domain.Core.Models.Enums;
using Psymend.Domain.Core.Services;
using Psymend.WebApi.Model;

namespace Psymend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var userId = Convert.ToInt32(User.Identity.Name);
            return Get(userId);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Please specify the correct userId" });
            }

            var model = _userService.GetUserById(userId);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody]CreateUserModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.PhoneNumber))
            {
                return BadRequest(new { message = "The phone number or email address must be filled in." });
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "The Password must be filled in." });
            }

            if (string.IsNullOrEmpty(model.Role))
            {
                return BadRequest(new { message = "The Role must be filled in." });
            }
            else if (model.Role.Equals(Role.Admin))
            {
                return BadRequest(new { message = "You cannot create a user with this role." });
            }

            var domainModel = new Domain.Core.Models.CreateUserModel
            {
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Role = model.Role
            };

            try
            {
                _userService.CreateUser(domainModel);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new {message = e.Message });
            }

            return CreatedAtAction(nameof(Get), new { id = domainModel.Id }, domainModel);
        }
    }
}