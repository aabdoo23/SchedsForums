using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseCommandResponseDTO : BaseIdResponseDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}