using FluentValidation;
using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Queries.Common
{
    public class BaseGetPaginatedValidator<TCommand, TResponse> : AbstractValidator<TCommand>
            where TCommand : BaseGetPaginatedQuery<TResponse>
    {
        public BaseGetPaginatedValidator()
        {
            RuleFor(request => request.PageNumber).NotNull().GreaterThan(0);
            RuleFor(request => request.PageSize).NotNull().GreaterThan(0);
        }
    }
}
