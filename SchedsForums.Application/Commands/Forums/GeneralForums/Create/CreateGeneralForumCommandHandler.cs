using SchedsForums.Application.Commands.Forums.Common;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommandHandler(
        IBaseRepository<GeneralForum> generalForumRepository,
        ICurrentUserService currentUserService)
                : CreateForumBaseCommandHandler<GeneralForum, CreateGeneralForumCommand, CreateGeneralForumCommandResponseDTO>(generalForumRepository, currentUserService)
    {
        protected override void SetForumSpecificProperties(GeneralForum forum, CreateGeneralForumCommand request)
        {
        }
    }
}