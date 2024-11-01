using MediatR;
using SchedsForums.Application.Interfaces;

namespace SchedsForums.Application.Queries.Admins.GetPendingModerators
{
    public class GetPendingModeratorsQueryHandler(
        IPendingModeratorRepository repository)
        : IRequestHandler<GetPendingModeratorsQuery, GetPendingModeratorsQueryResponseDTO>
    {
        private readonly IPendingModeratorRepository _repository = repository 
            ?? throw new ArgumentNullException(nameof(IPendingModeratorRepository));

        public async Task<GetPendingModeratorsQueryResponseDTO> Handle(
            GetPendingModeratorsQuery request,
            CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber - 1;
            int pageSize = request.PageSize;
            int start = pageNumber * pageSize;
            int end = start + pageSize - 1;
            var pendingModeratorsQueryResult = await _repository.GetFromTo(start, end);

            return new GetPendingModeratorsQueryResponseDTO
            {
                PendingModerators = pendingModeratorsQueryResult,
                ReturnedCount = pendingModeratorsQueryResult.Count()
            };
        }
    }
}