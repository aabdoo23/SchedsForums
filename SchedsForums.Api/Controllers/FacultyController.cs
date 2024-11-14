using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Faculties.Create;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateFacultyAsync([FromBody] CreateFacultyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
