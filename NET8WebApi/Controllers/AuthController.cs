using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET8WebApi.Services;

namespace NET8WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginModel model)
        {
            // Replace with actual user validation logic
            if (model.Username == "Kuleen" && model.Password == "Kuleen24@")
            {
                var token = _tokenService.GenerateToken(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
