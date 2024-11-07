using MediatR;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Queries.PendingModerators.GetPendingModerators
{
    public class GetPendingModeratorsQueryHandler(
        IPendingModeratorRepository repository)
        : IRequestHandler<GetPendingModeratorsQuery, GetPendingModeratorsQueryResponseDTO>
    {
        private readonly IPendingModeratorRepository _pendingModeratorsRepository = repository
            ?? throw new ArgumentNullException(nameof(repository));

        public async Task<GetPendingModeratorsQueryResponseDTO> Handle(
            GetPendingModeratorsQuery request,
            CancellationToken cancellationToken)
        {
            var pendingModeratorsQueryResult = await _pendingModeratorsRepository.GetPaginatedAsync(
                request.PageNumber,
                request.PageSize);

            return new GetPendingModeratorsQueryResponseDTO
            {
                Data = pendingModeratorsQueryResult.Data,
                ReturnedCount = pendingModeratorsQueryResult.ReturnedCount,
                TotalCount = pendingModeratorsQueryResult.TotalCount,
                PageNumber = pendingModeratorsQueryResult.PageNumber,
                PageSize = pendingModeratorsQueryResult.PageSize
            };
        }
    }
}