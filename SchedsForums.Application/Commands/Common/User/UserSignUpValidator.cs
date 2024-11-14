using FluentValidation;

namespace SchedsForums.Application.Commands.Common.User
{
    public abstract class UserSignUpValidator<TCommand, TResponse> : AbstractValidator<TCommand>
            where TCommand : UserSignUpCommand<TResponse>
    {
        protected UserSignUpValidator()
        {
            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("FullName is required.")
                .Length(2, 50).WithMessage("FullName must be between 2 and 50 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");
        }
    }
}