using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Queries.Common.DTOs
{
    public class PaginatedEntityDTO<T> where T : BaseEntity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IList<T> Data { get; set; }
    }
}
