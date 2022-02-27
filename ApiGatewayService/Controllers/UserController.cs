using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayService.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("/v1/user")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var result = await _userRepository.InsertUser(user);
            return Ok(result);
        }

        [HttpPut("/v1/user")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userRepository.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("/v1/user/{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            await _userRepository.DeleteUser(username);
            return Ok(username);
        }

        [HttpGet("/v1/user/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var result = await _userRepository.GetUser(username);
            return Ok(result);
        }
    }
}
