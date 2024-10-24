using SchedsForums.Application.BaseDTOs;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseDTO : BaseCommandReturnDTO
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }

        public CreateCourseDTO(Course course)
        {
            CourseCode = course.CourseCode;
            CourseName = course.CourseName;
            CourseDescription = course.Description;
            Id = course.Id;
        }
    }
}