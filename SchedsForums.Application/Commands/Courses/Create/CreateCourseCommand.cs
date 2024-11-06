using MediatR;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResponseDTO>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
