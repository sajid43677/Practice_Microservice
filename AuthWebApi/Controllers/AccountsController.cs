using JwtConfiguration;
using JwtConfiguration.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountsController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost("Login")]
        public ActionResult<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(request);
            if (authenticationResponse == null)
            {
                return Unauthorized();
            }

            return authenticationResponse;
        }
    }
}
