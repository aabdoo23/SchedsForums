using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommandHandler(IBaseRepository<GeneralForum> generalForum, ICurrentUserService currentUserService) 
        : IRequestHandler<CreateGeneralForumCommand, CreateGeneralForumCommandResponseDTO>
    {
        private readonly IBaseRepository<GeneralForum> _generalForumRepository = generalForum 
            ?? throw new ArgumentNullException(nameof(generalForum));
        private readonly ICurrentUserService _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));
        public async Task<CreateGeneralForumCommandResponseDTO> Handle(CreateGeneralForumCommand request, CancellationToken cancellationToken)
        {
            var createdById = _currentUserService.GetUserId();
            var newGeneralForum = new GeneralForum
            {
                Title = request.Title,
                Description = request.Description,
                Guidelines = request.Guidelines,
                CreatedById = createdById
            };
            await _generalForumRepository.InsertAsync(newGeneralForum);
            return new CreateGeneralForumCommandResponseDTO
            {
                Title = newGeneralForum.Title,
                Description = newGeneralForum.Description,
                Guidelines = newGeneralForum.Guidelines,
                CreatedById = newGeneralForum.CreatedById,
                Id = newGeneralForum.Id
            };
        }
    }
}
