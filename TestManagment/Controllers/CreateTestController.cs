using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagment.Domain.Entities;
using TestManagment.Services.CreateTest;
using TestManagment.Shared.Dtos;

namespace TestManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTestController : ControllerBase
    {
        private CreateTestService CreateTestService { get; }

        public CreateTestController(CreateTestService createTestService)
        {
            CreateTestService = createTestService;
        }

        [HttpPost("MakeTest")]
        public async Task<IActionResult> MakeTest(CreateTestDto createTestDto)
        {
            if (createTestDto == null)
            {
                return BadRequest("Test object must be not null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await CreateTestService.MakeTest(createTestDto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(QuestionDto question)
        {
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
