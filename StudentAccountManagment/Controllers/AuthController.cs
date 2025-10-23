using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentAccountManagment.ApplicationLayer;
using StudentAccountManagment.Shared;

namespace StudentAccountManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("user is null");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest(string.Join(",", ModelState));
            }

            try
            {
                var token = await authService.Login(loginUser);
                return Ok(token);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await authService.LogOut();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPost("RegisterTeacher")]
        public async Task<IActionResult> RegisterTeacher(RegisterUser registerUser)
        {
            if (registerUser == null)
            {
                return BadRequest("user is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(",", ModelState));
            }

            try
            {
                var token = await authService.RegisterTeacher(registerUser);
                return Ok(token);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudent(RegisterUser registerUser)
        {
            Log.Logger.Information("Student Registeration Endpoint");
            if (registerUser == null)
            {
                return BadRequest("user is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(",", ModelState));
            }

            try
            {
                var token = await authService.RegisterStudent(registerUser);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost("testJwt")]
        public IActionResult testJwt()
        {
            return Ok("nice");
        }

    }
}
