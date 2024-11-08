using SchedsForums.Application.Commands.Forums.Common;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.MajorForums.Create
{
    public class CreateMajorForumCommandHandler(
        IBaseRepository<MajorForum> majorForumRepository,
        ICurrentUserService currentUserService)
                : CreateForumBaseCommandHandler<MajorForum, CreateMajorForumCommand, CreateMajorForumCommandResponseDTO>(majorForumRepository, currentUserService)
    {
        protected override void SetForumSpecificProperties(MajorForum forum, CreateMajorForumCommand request)
        {
            forum.MajorId = request.MajorId;
        }
    }
}