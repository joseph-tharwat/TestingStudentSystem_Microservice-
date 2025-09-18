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
            await CreateTestService.MakeTest(createTestDto);
            return Created();
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(QuestionDto question)
        {
            await CreateTestService.CreateQuestion(question);
            return Created();
        }

        [HttpPost("CreateQuestions")]
        public async Task<IActionResult> CreateQuestions(List<QuestionDto>  questions)
        {
            await CreateTestService.CreateQuestions(questions);
            return Created();
        }

    }
}
