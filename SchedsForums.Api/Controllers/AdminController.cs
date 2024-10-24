using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Admins.Create;

namespace SchedsForums.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminCommand createAdminCommand)
        {
            var result = await _mediator.Send(createAdminCommand);
            return Ok(result);
        }
    }
}
