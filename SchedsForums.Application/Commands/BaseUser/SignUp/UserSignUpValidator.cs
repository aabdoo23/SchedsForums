using FluentValidation;
using SchedsForums.Application.Commands.BaseUser.SignUp.DTOs;

namespace SchedsForums.Application.Commands.BaseUser.SignUp
{
    public class UserSignUpValidator : AbstractValidator<UserSignUpRequestDTO>
    {
        public UserSignUpValidator()
        {
            RuleFor(student => student.FullName)
                .NotEmpty().WithMessage("FullName is required.")
                .Length(2, 50).WithMessage("FullName must be between 2 and 50 characters.");

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
