using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Majors.Create;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> CreateMajor([FromBody] CreateMajorCommand command)
        {
            if (command == null)
                return BadRequest("Invalid major request");
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
