using AuthenticationKeycloak.WebApi.Interfaces;
using AuthenticationKeycloak.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationKeycloak.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AuthenticationController(IAuthentication tokenService)
        {
            _authenticationService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            return Ok(_authenticationService.Login(login));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok("User authentication ok.");
        }
    }
}
