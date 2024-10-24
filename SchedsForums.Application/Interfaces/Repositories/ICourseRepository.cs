using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Interfaces.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<bool> IsCourseCodeUnique(string courseCode);
    }
}
