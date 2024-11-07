using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Queries.Common.DTOs
{
    public class BaseGetPaginatedResponseDTO<T> : BaseGetPaginatedDTO<T> where T : BaseResponseDTO
    {
    }
}
