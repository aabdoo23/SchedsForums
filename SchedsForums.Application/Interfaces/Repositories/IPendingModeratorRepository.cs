using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Interfaces.Repositories
{
    public interface IPendingModeratorRepository : IBaseRepository<PendingModerator>
    {
        Task<IEnumerable<PendingModerator>> GetFromTo(int pageNumber, int pageSize);
    }
}
