using FluentValidation;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        private readonly IBaseUserRepository _baseUserRepository;
        public CreateStudentValidator(IBaseUserRepository baseUserRepository)
        {
            _baseUserRepository = baseUserRepository;

            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");                

            RuleFor(student => student.Password)
                .NotEmpty().WithMessage("PasswordHash is required.")
                .MinimumLength(8).WithMessage("PasswordHash must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("PasswordHash must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("PasswordHash must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("PasswordHash must contain at least one digit.");

            RuleFor(student => student.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Length(2, 50).WithMessage("UserName must be between 2 and 50 characters.")
                .MustAsync(UserNameUniqueAsync).WithMessage("The specified UserName is already in use.");

            RuleFor(student => student.Email)
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
