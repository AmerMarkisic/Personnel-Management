using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTestingPrototype.App.Models;
using WebTestingPrototype.App.Services.UserService;

namespace WebTestingPrototype.App.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/login")]
        public ActionResult Login([FromBody] LoginRequestModel model)
        {
            var response = _userService.Authenticate(model);
            if (response == null) return new BadRequestObjectResult(new {message = "Username or Password is incorrect"});
            return Ok(response);
        }
    }
}