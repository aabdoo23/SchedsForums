using FluentValidation;
using SchedsForums.Application.Commands.Common.User;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpValidator : UserSignUpValidator<ModeratorSignUpCommand, ModeratorSignUpResponseDTO>
    {
        public ModeratorSignUpValidator()
        {
            RuleFor(x => x.Reason).MinimumLength(15);
        }
    }
}
