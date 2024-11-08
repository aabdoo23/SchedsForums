using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchedsForums.Application.Queries.PendingModerators.GetPendingModerators;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeratorRequestsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [Authorize(Roles = nameof(Admin))]
        [HttpGet("PendingModerators")]
        public async Task<IActionResult> GetModeratorSignUpRequestsAsync([FromBody] GetPendingModeratorsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
