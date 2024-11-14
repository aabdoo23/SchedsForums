using MediatR;

namespace SchedsForums.Application.Queries.Common
{
    public abstract class BaseGetPaginatedQuery<TResponse> : IRequest<TResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
