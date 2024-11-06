using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Admins.CreateCourse
{
    public class CreateCourseCommandResponseDTO : BaseResponseDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}