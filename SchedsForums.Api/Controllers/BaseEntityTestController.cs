using Microsoft.AspNetCore.Mvc;
using SchedsForums.Persistence.Contexts;

namespace SchedsForums.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseEntityTestController : Controller
    {
        private readonly ForumsDbContext _context;
        public BaseEntityTestController(ForumsDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.BaseEntities);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseEntity entity)
        {
            await _context.BaseEntities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

    }
}
