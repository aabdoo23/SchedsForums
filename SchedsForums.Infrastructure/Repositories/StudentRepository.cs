using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ForumsDbContext _context;
        public StudentRepository(ForumsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
