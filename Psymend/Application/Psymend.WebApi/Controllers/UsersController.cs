using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psymend.WebApi.Model;
using Psymend.WebApi.Services;

namespace Psymend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public IActionResult GetAll()
        {
            return Ok($"UserId: {User.Identity.Name}");
        }
    }
}