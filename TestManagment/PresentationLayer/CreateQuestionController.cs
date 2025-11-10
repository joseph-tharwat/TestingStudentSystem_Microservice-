using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestManagment.Services.CreateTest;
using TestManagment.Shared.Dtos;

namespace TestManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuestionController : ControllerBase
    {
        private CreateQuestionService CreateTestService { get; }

        public CreateQuestionController(CreateQuestionService createTestService)
        {
            CreateTestService = createTestService;
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(QuestionDto question)
        {
            Log.Logger.Information("Create Question Endpoint");
            if(question == null)
            {
                return BadRequest("question must be not null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await CreateTestService.CreateQuestion(question);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateQuestions")]
        public async Task<IActionResult> CreateQuestions(List<QuestionDto>  questions)
        {
            if (questions == null)
            {
                return BadRequest("question must be not null");
            }
            if (questions.Count == 0)
            {
                return BadRequest("At least send one question.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await CreateTestService.CreateQuestions(questions);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
