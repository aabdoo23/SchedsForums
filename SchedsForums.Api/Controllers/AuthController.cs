using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.BaseUsers.Login;
using SchedsForums.Application.Commands.Moderators.SignUp;
using SchedsForums.Application.Commands.Students.SignUp;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

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

        [HttpPost("ModeratorSignUp")]
        public async Task<IActionResult> ModeratorSignUpAsync([FromBody] ModeratorSignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

