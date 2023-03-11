using BuberDinnerApp.Application.Services.Authentication;
using BuberDinnerApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinnerApp.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService iAuthenticationService;

        public AuthenticationController(IAuthenticationService _iAuthenticationService)
        {
            iAuthenticationService = _iAuthenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = iAuthenticationService.Register(
                registerRequest.FirstName,
                registerRequest.LastName,
                registerRequest.Email,
                registerRequest.Password
                );
            return Ok(authResult);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = iAuthenticationService.Login(
                loginRequest.Email,
                loginRequest.Password
                );
            return Ok(authResult);
        }
    }
}
