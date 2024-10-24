using MediatR;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand, CreateCourseDTO>
    {
        private readonly ICourseRepository _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));

        public async Task<CreateCourseDTO> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                CourseCode = request.CourseCode,
                CourseName = request.CourseName,
                Description = request.CourseDescription
            };

            var created = await _courseRepository.InsertAsync(course);

            return new CreateCourseDTO(created);
        }
    }
}
