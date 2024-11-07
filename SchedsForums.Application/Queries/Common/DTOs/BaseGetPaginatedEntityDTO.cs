using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Queries.Common.DTOs
{
    public class BaseGetPaginatedEntityDTO<T> : BaseGetPaginatedDTO<T> where T : BaseEntity
    {
    }
}
