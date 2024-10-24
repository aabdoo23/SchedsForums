using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Users.BaseUser.Login;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (command == null)
                return BadRequest("Invalid login request");
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result); 
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid credentials");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

