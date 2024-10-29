using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.BaseUsers.Login;
using SchedsForums.Application.Commands.Students.SignUp;

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
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync([FromBody] StudentSignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

