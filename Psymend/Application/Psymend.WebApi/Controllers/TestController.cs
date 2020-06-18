using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psymend.Domain.Core.Models.Enums;
using Psymend.Domain.Core.Services;

namespace Psymend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestService _service;

        public TestController(
            ITestService service, 
            ILogger<TestController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = Role.Client)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var baseUrl = Request.GetDisplayUrl();

            var userId = Convert.ToInt32(User.Identity.Name);
            var model = _service.GetTests(userId, baseUrl);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}