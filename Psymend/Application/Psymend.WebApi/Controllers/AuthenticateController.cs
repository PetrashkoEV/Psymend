using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psymend.WebApi.Authenticate;
using Psymend.WebApi.Model;

namespace Psymend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthenticateController(IAuthService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }
    }
}