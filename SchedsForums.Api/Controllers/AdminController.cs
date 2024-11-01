using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Commands.Admins.Create;
using SchedsForums.Application.Queries.Admins.GetPendingModerators;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(Admin))]
    public class AdminController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task<IActionResult> CreateAdminAsync([FromBody] CreateAdminCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("PendingModerators")]
        public async Task<IActionResult> GetModeratorSignUpRequestsAsync([FromBody] GetPendingModeratorsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}