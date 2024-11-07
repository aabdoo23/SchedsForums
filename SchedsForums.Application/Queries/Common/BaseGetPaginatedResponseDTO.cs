using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Queries.Common
{
    public class BaseGetPaginatedResponseDTO<T> where T : BaseEntity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int ReturnedCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
