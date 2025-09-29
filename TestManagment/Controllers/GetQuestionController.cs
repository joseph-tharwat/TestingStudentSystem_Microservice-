using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagment.ApplicationLayer.GetQuestion;
using TestManagment.Shared.Dtos;

namespace TestManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetQuestionController : ControllerBase
    {
        private readonly GetQuestionService getQuestionService;

        public GetQuestionController(GetQuestionService getQuestionService)
        {
            this.getQuestionService = getQuestionService;
        }

        [HttpGet("GetNextQuestion")]
        public async Task<ActionResult<NextQuestion>> GetNextQuestion([FromQuery]StudentProgress studentProgress)
        {
            try
            {
                var nextQuestion = await getQuestionService.GetNextQuestionAsync(studentProgress);
                return Ok(nextQuestion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
