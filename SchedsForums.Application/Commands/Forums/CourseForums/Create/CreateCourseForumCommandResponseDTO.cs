using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.CourseForums.Create
{
    public class CreateCourseForumCommandResponseDTO : CreateForumBaseResponseDTO
    {
        public Guid CourseId { get; set; }
    }
}