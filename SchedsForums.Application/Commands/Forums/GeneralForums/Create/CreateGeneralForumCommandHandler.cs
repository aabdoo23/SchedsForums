using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities.Forums;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommandHandler(IBaseRepository<GeneralForum> generalForum) : IRequestHandler<CreateGeneralForumCommand, CreateGeneralForumCommandResponseDTO>
    {
        private readonly IBaseRepository<GeneralForum> _generalForumRepository = generalForum 
            ?? throw new ArgumentNullException(nameof(generalForum));
        public async Task<CreateGeneralForumCommandResponseDTO> Handle(CreateGeneralForumCommand request, CancellationToken cancellationToken)
        {
            var newGeneralForum = new GeneralForum
            {
                Title = request.Title,
                Description = request.Description,
                Guidelines = request.Guidelines
            };
            await _generalForumRepository.InsertAsync(newGeneralForum);
            return new CreateGeneralForumCommandResponseDTO
            {
                Title = newGeneralForum.Title,
                Description = newGeneralForum.Description,
                Guidelines = newGeneralForum.Guidelines
            };

        }
    }
}
