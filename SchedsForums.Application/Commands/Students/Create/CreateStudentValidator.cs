using FluentValidation;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentDTO>
    {
        public CreateStudentValidator()
        {
            // Rule for Name: Required, Minimum length of 2 characters, Maximum length of 50
            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            // Rule for Email: Required, must be a valid email format
            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Rule for Password: Required, at least 8 characters, must contain at least 1 uppercase, 1 lowercase, 1 digit
            RuleFor(student => student.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");

            // Optional rule for Major: If provided, it should not be null
            RuleFor(student => student.Major)
                .Must(major => major == null || major.Id != null).WithMessage("Invalid Major.");
        }
    }
}
