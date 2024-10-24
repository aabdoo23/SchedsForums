using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class AdminRepository(SchedsForumsDbContext context) : BaseRepository<Admin>(context), IAdminRepository
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
