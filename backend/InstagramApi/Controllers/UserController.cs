using System.Threading.Tasks;
using InstagramApi.Models;
using InstagramApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstagramApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Autenticar(LoginModel username)
        {            
            return Ok(await _userService.Authenticate(username.UserName));
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(string userName)
        {
            return Ok(await _userService.CreateUser(userName));
        }

    }
}