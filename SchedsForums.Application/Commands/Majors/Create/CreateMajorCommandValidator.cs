using FluentValidation;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommandValidator : AbstractValidator<CreateMajorCommand>
    {
        public CreateMajorCommandValidator() { 
            RuleFor(x => x.MajorCode)
                .NotEmpty().WithMessage("Major code is required.")
                .MaximumLength(10).WithMessage("Major code must not exceed 10 characters.");
            RuleFor(x => x.MajorName)
                .NotEmpty().WithMessage("Major name is required.");
        }
    }
}
