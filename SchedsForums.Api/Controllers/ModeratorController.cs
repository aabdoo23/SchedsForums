using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Users.Moderators.Create;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeratorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateModerator([FromBody] CreateModeratorCommand createModeratorCommand)
        {
            var result = await _mediator.Send(createModeratorCommand);
            return Ok(result);
        }
    }
}
