using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Courses.Create;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize(Roles = nameof(Admin))]
        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourseAsync([FromBody] CreateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
