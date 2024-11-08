using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.Common
{
    public abstract class CreateForumBaseCommandHandler<TForum, TCommand, TResponse>(
        IBaseRepository<TForum> forumRepository,
        ICurrentUserService currentUserService)
        : IRequestHandler<TCommand, TResponse>
        where TForum : BaseForum, new()
        where TCommand : CreateForumBaseCommand<TResponse>
        where TResponse : CreateForumBaseResponseDTO, new()
    {
        private readonly IBaseRepository<TForum> _forumRepository = forumRepository 
            ?? throw new ArgumentNullException(nameof(forumRepository));
        private readonly ICurrentUserService _currentUserService = currentUserService 
            ?? throw new ArgumentNullException(nameof(currentUserService));

        protected abstract void SetForumSpecificProperties(TForum forum, TCommand request);

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var createdById = _currentUserService.GetUserId();
            var forum = new TForum
            {
                Title = request.Title,
                Description = request.Description,
                Guidelines = request.Guidelines,
                CreatedById = createdById
            };

            SetForumSpecificProperties(forum, request);

            await _forumRepository.InsertAsync(forum);

            return new TResponse
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                CreatedById = forum.CreatedById,
                Guidelines = forum.Guidelines
            };
        }
    }
}
