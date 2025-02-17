using Application.DTOs;
using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Auctify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly RegisterService _registerService;


        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerModel)
        {
            var user = await _registerService.Register(registerModel);
            return Ok("User is registered successfully!");
        }

    }
}
