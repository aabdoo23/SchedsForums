using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseCommandHandler(IBaseRepository<Course> courseRepository) : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponseDTO>
    {
        private readonly IBaseRepository<Course> _courseRepository = courseRepository
            ?? throw new ArgumentNullException(nameof(courseRepository));

        public async Task<CreateCourseCommandResponseDTO> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                CourseCode = request.CourseCode,
                CourseName = request.CourseName
            };

            await _courseRepository.InsertAsync(course);
            return new CreateCourseCommandResponseDTO
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName
            };
        }
    }
}
