using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Interfaces
{
    public interface IPendingModeratorRepository : IBaseRepository<PendingModerator>
    {
        public Task<IEnumerable<PendingModerator>> GetFromTo(int start, int end);
    }
}
