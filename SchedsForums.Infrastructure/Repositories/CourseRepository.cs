using Microsoft.EntityFrameworkCore;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities;
using SchedsForums.Infrastructure.Contexts;
using SchedsForums.Infrastructure.Repositories.Common;

namespace SchedsForums.Infrastructure.Repositories
{
    public class CourseRepository(SchedsForumsDbContext context) : BaseRepository<Course>(context),ICourseRepository
    {
        private readonly SchedsForumsDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> IsCourseCodeUnique(string courseCode)
        {
            return await _context.Courses.AllAsync(x => x.CourseCode != courseCode);
        }
    }
}
