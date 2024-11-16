using MediatR;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpCommandHandler(
        IPendingModeratorRepository moderatorSignUpRequestRepository,
        IPasswordService passwordService)
        : IRequestHandler<ModeratorSignUpCommand, ModeratorSignUpResponseDTO>
    {
        private readonly IPendingModeratorRepository _moderatorSignUpRequestRepository = moderatorSignUpRequestRepository
            ?? throw new ArgumentNullException(nameof(moderatorSignUpRequestRepository));
        private readonly IPasswordService _passwordService = passwordService
            ?? throw new ArgumentNullException(nameof(passwordService));

        public async Task<ModeratorSignUpResponseDTO> Handle(ModeratorSignUpCommand command, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(command.Password);

            var pendingModerator = new PendingModerator
            {
                Name = command.FullName,
                Username = command.UserName,
                Email = command.Email,
                PasswordHash = hashedPassword,
                Reason = command.Reason,
                Status = RequestStatus.Pending,
            };

            await _moderatorSignUpRequestRepository.InsertAsync(pendingModerator);

            return new ModeratorSignUpResponseDTO
            {
                Id = pendingModerator.Id,
                FullName = pendingModerator.Name,
                UserName = pendingModerator.Username,
                Email = pendingModerator.Email,
                Reason = pendingModerator.Reason,
            };
        }
    }
}