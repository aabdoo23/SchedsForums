using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpCommandHandler(
        IBaseRepository<PendingModerator> moderatorSignUpRequestRepository,
        IPasswordService passwordService)
        : IRequestHandler<ModeratorSignUpCommand, ModeratorSignUpResponseDTO>
    {
        private readonly IBaseRepository<PendingModerator> _moderatorSignUpRequestRepository = moderatorSignUpRequestRepository 
            ?? throw new ArgumentNullException(nameof(moderatorSignUpRequestRepository));
        private readonly IPasswordService _passwordService = passwordService;

        public async Task<ModeratorSignUpResponseDTO> Handle(ModeratorSignUpCommand command, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(command.Password);

            var PendingModerator = new PendingModerator
            {
                Name = command.FullName,
                Username = command.UserName,
                Email = command.Email,
                PasswordHash = hashedPassword,
                Reason = command.Reason,
                Status = ModeratorStatus.Pending,
            };

            //is this correct? reassigning the variable and using that to return, or is it redundant
            //i did it for the id mainly, but now i'm not sure
            PendingModerator = await _moderatorSignUpRequestRepository.InsertAsync(PendingModerator);

            return new ModeratorSignUpResponseDTO
            {
                Id = PendingModerator.Id.ToString(),
                FullName = PendingModerator.Name,
                UserName = PendingModerator.Username,
                Email = PendingModerator.Email,
                Reason = PendingModerator.Reason,
            };
        }
    }
}