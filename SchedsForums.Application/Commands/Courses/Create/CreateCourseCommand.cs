using MediatR;

namespace SchedsForums.Application.Commands.Courses.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResponseDTO>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
