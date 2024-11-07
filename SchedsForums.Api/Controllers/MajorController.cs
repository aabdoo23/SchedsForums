using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Majors.Create;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateMajorAsync([FromBody] CreateMajorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
