using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Queries.Admins.GetPendingModerators
{
    public class GetPendingModeratorsQueryHandler(
        IBaseRepository<PendingModerator> repository)
        : IRequestHandler<GetPendingModeratorsQuery, GetPendingModeratorsQueryResponseDTO>
    {
        private readonly IBaseRepository<PendingModerator> _pendingModeratorsRepository = repository
            ?? throw new ArgumentNullException(nameof(IBaseRepository<PendingModerator>));

        public async Task<GetPendingModeratorsQueryResponseDTO> Handle(
            GetPendingModeratorsQuery request,
            CancellationToken cancellationToken)
        {
            var pendingModeratorsQueryResult = await _pendingModeratorsRepository.GetFromTo(request.PageNumber, request.PageSize);
            var totalCount = await _pendingModeratorsRepository.GetTotalCount();

            return new GetPendingModeratorsQueryResponseDTO
            {
                PendingModerators = pendingModeratorsQueryResult,
                ReturnedCount = pendingModeratorsQueryResult.Count(),
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
        }
    }
}