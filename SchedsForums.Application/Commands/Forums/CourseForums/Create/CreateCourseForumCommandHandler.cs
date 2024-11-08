using SchedsForums.Application.Commands.Forums.Common;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.CourseForums.Create
{
    public class CreateCourseForumCommandHandler(
        IBaseRepository<CourseForum> courseForumRepository,
        ICurrentUserService currentUserService)
                : CreateForumBaseCommandHandler<CourseForum, CreateCourseForumCommand, CreateCourseForumCommandResponseDTO>(courseForumRepository, currentUserService)
    {
        protected override void SetForumSpecificProperties(CourseForum forum, CreateCourseForumCommand request)
        {
            forum.CourseId = request.CourseId;
        }
    }
}