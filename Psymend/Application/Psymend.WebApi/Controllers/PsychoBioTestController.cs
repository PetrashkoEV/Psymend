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
    [Route("api/test/psychobio")]
    public class PsychoBioTestController : ControllerBase
    {
        private readonly ILogger<PsychoBioTestController> _logger;
        private readonly IPsychoBioTestService _service;

        public PsychoBioTestController(
            IPsychoBioTestService service,
            ILogger<PsychoBioTestController> logger)
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
            var model = _service.GetTestResultById(testId, userId);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetQuestions()
        {
            var model = _service.GetQuestions();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ProcessData([FromBody] PsychoBioTestModel model)
        {
            return Ok();
        }
    }
}