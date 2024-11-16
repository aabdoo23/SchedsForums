using FluentValidation;

namespace SchedsForums.Application.Commands.ForumRequests.Create
{
    public class CreateForumRequestCommandValidator : AbstractValidator<CreateForumRequestCommand>
    {
        public CreateForumRequestCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Guidelines)
                .NotEmpty().WithMessage("Guidelines are required.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason is required.")
                .MaximumLength(500).WithMessage("Reason must not exceed 500 characters.");

            RuleFor(x => x.ForumType)
                .IsInEnum().WithMessage("Invalid forum type.");
        }
    }
}
