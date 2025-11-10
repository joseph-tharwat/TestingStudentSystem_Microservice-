using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
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

        [HttpPost("CreateTest")]
        public async Task<IActionResult> CreateTest(CreateTestDto createTestDto)
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
                await CreateTestService.CreateTest(createTestDto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddQuestionToTest")]
        public async Task<IActionResult> AddQuestionToTest(ModifyTestRequest modifyTestRequest)
        {
            try
            {
                await CreateTestService.AddQuestionToTest(modifyTestRequest);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Question was added successfully");
        }

        [HttpPost("RemoveQuestionToTest")]
        public async Task<IActionResult> RemoveQuestionToTest(ModifyTestRequest modifyTestRequest)
        {
            try
            {
                await CreateTestService.RemoveQuestionToTest(modifyTestRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Question was removed successfully successfully");
        }
    }
}
