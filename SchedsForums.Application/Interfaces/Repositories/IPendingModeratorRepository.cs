using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Queries.Common.DTOs;
using SchedsForums.Application.Queries.PendingModerators.DTOs;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Interfaces.Repositories
{
    public interface IPendingModeratorRepository : IBaseRepository<PendingModerator>
    {
        public Task<PaginatedResponseDTO<BasePendingModeratorResponseDTO>> GetPaginatedPendingModeratorsAsync(int pageNumber, int pageSize);
        public Task PromoteToModeratorAsync(Guid pendingModeratorId);
    }
}
