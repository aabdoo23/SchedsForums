using MediatR;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseCommand : IRequest<CreateCourseDTO>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
    }
}
