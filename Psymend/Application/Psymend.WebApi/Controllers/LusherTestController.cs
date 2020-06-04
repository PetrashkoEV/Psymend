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
    [Route("api/test/lusher")]
    public class LusherTestController : Controller
    {
        //private readonly ILogger<UserController> _logger;
        private readonly ILusherTestService _service;

        public LusherTestController(ILusherTestService service)
        {
            _service = service;
        }

        [HttpGet("{testId}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int testId)
        {
            if (testId <= 0)
            {
                return BadRequest(new { message = "Please specify the correct testId" });
            }

            var model = new { };

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
        public IActionResult CreateTest([FromBody]LusherTestModel model)
        {
            if (model.ColorSet == null || model.ColorSet.Count != 2)
            {
                return BadRequest(new { message = "The color set is not set. please send the correct request" });
            }

            try
            {
                var userId = Convert.ToInt32(User.Identity.Name);
                _service.Start(model.ColorSet, userId);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {message = e.Message });
            }

            return Ok(model);
        }
    }
}