using FluentValidation;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(student => student.Password)
                .NotEmpty().WithMessage("PasswordHash is required.")
                .MinimumLength(8).WithMessage("PasswordHash must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("PasswordHash must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("PasswordHash must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("PasswordHash must contain at least one digit.");
        }
    }
}
