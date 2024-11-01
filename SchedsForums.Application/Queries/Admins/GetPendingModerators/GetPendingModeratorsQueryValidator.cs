using FluentValidation;

namespace SchedsForums.Application.Queries.Admins.GetPendingModerators
{
    public class GetPendingModeratorsQueryValidator : AbstractValidator<GetPendingModeratorsQuery>
    {
        public GetPendingModeratorsQueryValidator()
        {
            RuleFor(request => request.PageNumber).NotNull().GreaterThan(0);
            RuleFor(request => request.PageSize).NotNull().GreaterThan(0);
        }
    }
}
