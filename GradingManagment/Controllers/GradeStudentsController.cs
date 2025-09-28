using GradingManagment.ApplicationLayer;
using GradingManagment.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradingManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeStudentsController : ControllerBase
    {
        private readonly GradeQuestionService gradeQuestionService;

        public GradeStudentsController(GradeQuestionService gradeQuestionService)
        {
            this.gradeQuestionService = gradeQuestionService;
        }

        [HttpPost("GradeQuestion")]
        public async Task<IActionResult> GradeQuestion(StudentAnswer studentAnswer)
        {
            if (studentAnswer == null)
            {
                return BadRequest("Answer is null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(string.Join(",", ModelState));
            }
            try
            {
                await gradeQuestionService.GradeStudentAnswerAsync(studentAnswer);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
