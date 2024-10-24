using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Faculties.Create;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateFaculty([FromBody] CreateFacultyCommand command)
        {
            if (command == null)
                return BadRequest("Invalid faculty request");
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
