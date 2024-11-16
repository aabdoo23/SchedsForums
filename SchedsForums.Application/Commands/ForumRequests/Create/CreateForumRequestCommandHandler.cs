using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.ForumRequests.Create
{
    public class CreateForumRequestCommandHandler (IBaseRepository<ForumRequest> forumRequestRepository, ICurrentUserService currentUserService)
        : IRequestHandler<CreateForumRequestCommand, CreateForumRequestCommandResponseDTO>
    {
        private readonly IBaseRepository<ForumRequest> _forumRequestRepository = forumRequestRepository
            ?? throw new ArgumentNullException(nameof(forumRequestRepository));
        private readonly ICurrentUserService _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));
        public async Task<CreateForumRequestCommandResponseDTO> Handle(CreateForumRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var forumRequest = new ForumRequest
            {
                Title = request.Title,
                Description = request.Description,
                Guidelines = request.Guidelines,
                Reason = request.Reason,
                ForumType = request.ForumType,
                RequestStatus = RequestStatus.Pending,
                RequestedById = userId
            };
            await _forumRequestRepository.InsertAsync(forumRequest);

            return new CreateForumRequestCommandResponseDTO
            {
                Id = forumRequest.Id,
                Title = forumRequest.Title,
                Description = forumRequest.Description,
                Guidelines = forumRequest.Guidelines,
                Reason = forumRequest.Reason,
                ForumType = forumRequest.ForumType,
                RequestStatus = forumRequest.RequestStatus
            };

        }
    }
}
