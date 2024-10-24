using FluentValidation;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.BaseUser
{
    public abstract class BaseCreateUserValidator<T> : AbstractValidator<T> where T : BaseCreateUserCommand
    {
        private readonly IBaseUserRepository _baseUserRepository;

        protected BaseCreateUserValidator(IBaseUserRepository baseUserRepository)
        {
            _baseUserRepository = baseUserRepository;

            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Length(2, 50).WithMessage("UserName must be between 2 and 50 characters.")
                .MustAsync(UserNameUniqueAsync).WithMessage("The specified UserName is already in use.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(EmailUniqueAsync).WithMessage("The specified Email is already in use.");
        }

        private async Task<bool> EmailUniqueAsync(string email, CancellationToken cancellationToken)
        {
            return await _baseUserRepository.GetBaseUserByEmailAsync(email) == null;
        }

        private async Task<bool> UserNameUniqueAsync(string userName, CancellationToken cancellationToken)
        {
            return await _baseUserRepository.GetBaseUserByUserNameAsync(userName) == null;
        }
    }
}
