using SchedsForums.Domain.Entities.Users;
using SchedsForums.Infrastructure.Repositories.Common;
using SchedsForums.Interface.Repositories;
using SchedsForums.Persistence.Contexts;

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
