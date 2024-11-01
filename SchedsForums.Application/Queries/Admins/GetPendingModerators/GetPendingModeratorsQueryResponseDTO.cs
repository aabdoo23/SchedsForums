using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Queries.Admins.GetPendingModerators
{
    public class GetPendingModeratorsQueryResponseDTO
    {
        public IEnumerable<PendingModerator> PendingModerators { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int ReturnedCount { get; set; }
    }
}
