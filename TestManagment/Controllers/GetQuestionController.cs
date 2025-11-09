using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TestManagment.ApplicationLayer.GetQuestion;
using TestManagment.Domain.Entities;
using TestManagment.PresentaionLayer;
using TestManagment.Shared.Dtos;

namespace TestManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetQuestionController : ControllerBase
    {
        private readonly GetQuestionService getQuestionService;
        private readonly IHubContext<TestObservationHub> testObservationHub;

        public GetQuestionController(GetQuestionService getQuestionService, IHubContext<TestObservationHub> testObservationHub)
        {
            this.getQuestionService = getQuestionService;
            this.testObservationHub = testObservationHub;
        }

        [HttpGet("GetNextQuestion")]
        public async Task<ActionResult<NextQuestion>> GetNextQuestion([FromQuery]StudentProgress studentProgress)
        {
            try
            {
                var nextQuestion = await getQuestionService.GetNextQuestionAsync(studentProgress);
                await testObservationHub.Clients.All.SendAsync("StudentGotNextQuestion", Request.Headers["x-UserName"].ToString(), studentProgress);
                return Ok(nextQuestion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
