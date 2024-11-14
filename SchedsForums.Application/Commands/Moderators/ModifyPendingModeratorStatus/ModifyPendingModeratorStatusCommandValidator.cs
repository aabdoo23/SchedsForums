using FluentValidation;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Moderators.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusCommandValidator
        : AbstractValidator<ModifyPendingModeratorStatusCommand>
    {
        public ModifyPendingModeratorStatusCommandValidator()
        {
            RuleFor(x => x.ModeratorId.ToString())
                .NotEmpty()
                .MinimumLength(20);
            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}
