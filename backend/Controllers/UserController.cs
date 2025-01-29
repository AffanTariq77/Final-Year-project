using AdventureAdorn.API.Dto;
using AdventureAdorn.API.Models;
using AdventureAdorn.API.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdventureAdorn.API.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices) 
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] UserView userView)
        {
            try
            {
                var user = await _userServices.Signup(userView);
                return Ok(new
                {
                    message = "User registered successfully",
                    userId = user.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var result = await _userServices.Login(loginRequest.Email, loginRequest.Password);

                return Ok(new
                {
                    message = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during login" });
            }
        }

    }
}
