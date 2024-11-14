using FluentValidation;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommandValidator : AbstractValidator<CreateFacultyCommand>
    {
        public CreateFacultyCommandValidator()
        {
            RuleFor(x => x.ShortName)
                .NotEmpty().WithMessage("Short name is required.")
                .MaximumLength(10).WithMessage("Short name must not exceed 10 characters.");
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.");
        }
    }
}
