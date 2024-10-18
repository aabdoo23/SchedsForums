using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Students.Create;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO studentDto)
        {
            var createStudentCommand = new CreateStudentCommand { Student = studentDto };

            var result = await _mediator.Send(createStudentCommand);
            return Ok(result);
            //return CreatedAtAction(nameof(GetStudentById), new { id = result.Id }, result);
        }
    }
}
