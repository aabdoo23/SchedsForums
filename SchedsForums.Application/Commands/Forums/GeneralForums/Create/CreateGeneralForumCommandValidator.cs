using FluentValidation;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommandValidator : AbstractValidator<CreateGeneralForumCommand>
    {
        public CreateGeneralForumCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
