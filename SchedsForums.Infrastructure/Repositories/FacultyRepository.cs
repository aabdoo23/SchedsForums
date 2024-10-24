using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class FacultyRepository(SchedsForumsDbContext context) : BaseRepository<Faculty>(context), IFacultyRepository
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
