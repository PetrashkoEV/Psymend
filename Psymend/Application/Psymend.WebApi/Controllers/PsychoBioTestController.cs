using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psymend.Domain.Core.Models.PsychoBioTest;
using Psymend.Domain.Core.Services;
using Psymend.WebApi.Model;
using PsychoBioTestAnswerResultModel = Psymend.Domain.Core.Models.PsychoBioTest.PsychoBioTestAnswerResultModel;

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
        public IActionResult ProcessData([FromBody] List<PsychoBioTestResponseToQuestionModel> results)
        {
            var errorMessage = ValidateTestData(results);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(new { message = errorMessage });
            }

            var userId = Convert.ToInt32(User.Identity.Name);
            var testData = results.Select(item => new PsychoBioTestAnswerResponseModel
            {
                QuestionNumber = item.QuestionNumber,
                Answers = item.Answers.Select(answer => new PsychoBioTestAnswerResultModel
                {
                    CustomText = answer.CustomText,
                    AnswerNumber = answer.Number
                }).ToList()
            }).ToList();

            var result = _service.ProcessTestData(testData, userId);

            if (result == null)
            {
                return Problem();
            }

            return Ok(result);
        }

        private string ValidateTestData(IReadOnlyCollection<PsychoBioTestResponseToQuestionModel> response)
        {
            if (response == null)
            {
                return "The result model is empty";
            }

            var questions = _service.GetQuestions();

            if (response.Count != questions.Count)
            {
                return "The result model is empty";
            }

            foreach (var result in response)
            {
                var question = questions.FirstOrDefault(item => item.QuestionNumber == result.QuestionNumber);

                if (question == null)
                {
                    return $"The '{result.QuestionNumber}' result was not found in the list of questions.";
                }

                if (result.Answers.Count == 0)
                {
                    return $"The answer to the '{question.QuestionNumber}' question was not selected";
                }

                if (!question.AllowMultipleSelections && result.Answers.Count != 1)
                {
                    return $"The wrong number of answers was selected for the '{question.QuestionNumber}' question";
                }

                foreach (var userAnswer in result.Answers)
                {
                    var answer = question.Answers.FirstOrDefault(item => item.Number == userAnswer.Number);

                    if (answer == null)
                    {
                        return $"The '{userAnswer.Number}' answer was not found in the answer list for '{question.QuestionNumber}' question.";
                    }
                }
                
            }

            return string.Empty;
        }
    }
}