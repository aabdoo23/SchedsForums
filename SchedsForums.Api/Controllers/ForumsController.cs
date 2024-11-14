using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Forums.CourseForums.Create;
using SchedsForums.Application.Commands.Forums.FacultyForums.Create;
using SchedsForums.Application.Commands.Forums.GeneralForums.Create;
using SchedsForums.Application.Commands.Forums.MajorForums.Create;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ForumsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateGeneralForum([FromBody] CreateGeneralForumCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateMajorForum([FromBody] CreateMajorForumCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateCourseForum([FromBody] CreateCourseForumCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = nameof(Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateFacultyForum([FromBody] CreateFacultyForumCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
