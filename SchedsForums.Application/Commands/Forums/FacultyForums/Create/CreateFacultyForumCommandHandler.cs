using SchedsForums.Application.Commands.Forums.Common;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.FacultyForums.Create
{
    public class CreateFacultyForumCommandHandler(
        IBaseRepository<FacultyForum> facultyForumRepository,
        ICurrentUserService currentUserService)
                : CreateForumBaseCommandHandler<FacultyForum, CreateFacultyForumCommand, CreateFacultyForumCommandResponseDTO>(facultyForumRepository, currentUserService)
    {
        protected override void SetForumSpecificProperties(FacultyForum forum, CreateFacultyForumCommand request)
        {
            forum.FacultyId = request.FacultyId;
        }
    }
}