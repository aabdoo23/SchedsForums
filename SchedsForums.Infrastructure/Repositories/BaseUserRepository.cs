using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities.Users.Common;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class BaseUserRepository(SchedsForumsDbContext context) : BaseRepository<BaseUser>(context), IBaseUserRepository
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(SchedsForumsDbContext));

        public async Task<BaseUser> GetBaseUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<BaseUser> GetBaseUserByUserNameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Username == userName);
        }
    }
}
