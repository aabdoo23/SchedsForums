using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.BaseUser.Login.DTOs;
using SchedsForums.Application.Commands.BaseUser.SignUp.DTOs;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync([FromBody] UserSignUpRequestDTO command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

