using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.CourseForums.Create
{
    public class CreateCourseForumCommand : CreateForumBaseCommand<CreateCourseForumCommandResponseDTO>
    {
        public Guid CourseId { get; set; }
    }
}
