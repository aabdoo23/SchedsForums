using FluentValidation;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Admins.ModifyPendingModeratorStatus
{
    public class ModifyPendingModeratorStatusCommandValidator 
        : AbstractValidator<ModifyPendingModeratorStatusCommand>
    {
        private readonly IPendingModeratorRepository _pendingModeratorRepository;
        public ModifyPendingModeratorStatusCommandValidator(IPendingModeratorRepository pendingModeratorRepository)
        {
            _pendingModeratorRepository = pendingModeratorRepository ??
                throw new ArgumentNullException(nameof(pendingModeratorRepository));

            RuleFor(x => x.ModeratorId.ToString())
                .NotEmpty()
                .MinimumLength(20);
                //.Must(IsValidModeratorId);
            RuleFor(x => x.Status)
                .IsInEnum();
        }

        //private bool IsValidModeratorId(string moderatorId, CancellationToken token)
        //{
        //    var pendingModerator = _pendingModeratorRepository.GetById(moderatorId);
        //    return pendingModerator != null;
        //}
    }
}
