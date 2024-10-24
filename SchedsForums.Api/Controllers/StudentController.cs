using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Users.Students.Create;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand createStudentCommand)
        {
            var result = await _mediator.Send(createStudentCommand);
            return Ok(result);
        }
    }
}
