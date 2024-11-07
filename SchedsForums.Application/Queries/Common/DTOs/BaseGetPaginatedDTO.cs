namespace SchedsForums.Application.Queries.Common.DTOs
{
    public abstract class BaseGetPaginatedDTO<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int ReturnedCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
