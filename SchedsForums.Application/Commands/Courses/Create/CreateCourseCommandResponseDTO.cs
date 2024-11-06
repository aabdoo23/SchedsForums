using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Courses.CreateCourse
{
    public class CreateCourseCommandResponseDTO : BaseResponseDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}