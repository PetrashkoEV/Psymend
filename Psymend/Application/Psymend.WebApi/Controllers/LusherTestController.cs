using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psymend.Domain.Core.Models;
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
        private readonly ILogger<UserController> _logger;
        private readonly ILusherTestService _service;

        public LusherTestController(
            ILusherTestService service, 
            ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{testId}")]
        [Authorize(Roles = Role.Client)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int testId)
        {
            if (testId <= 0)
            {
                return BadRequest(new { message = "Please specify the correct testId" });
            }

            var userId = Convert.ToInt32(User.Identity.Name);
            var model = _service.GetLusherTestResultById(testId, userId);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [Authorize(Roles = Role.Client)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ProcessData([FromBody]LusherTestModel model)
        {
            if (model.ColorSet == null || model.ColorSet.Count != 2)
            {
                return BadRequest(new { message = "The color set is not correct. Please send the correct request" });
            }

            LusherTestResultModel result;
            try
            {
                var userId = Convert.ToInt32(User.Identity.Name);
                result = _service.ProcessData(model.ColorSet, userId);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new {message = e.Message });
            }

            return Ok(result);
        }
    }
}