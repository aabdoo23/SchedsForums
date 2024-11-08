using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Queries.Common.DTOs
{
    public class PaginatedResponseDTO<T> where T : BaseIdResponseDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IList<T> Data { get; set; }
    }
}
