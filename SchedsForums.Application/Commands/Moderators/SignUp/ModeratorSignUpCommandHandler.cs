using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpCommandHandler(
        IBaseRepository<ModeratorSignUpRequest> moderatorSignUpRequestRepository,
        IPasswordService passwordService)
        : IRequestHandler<ModeratorSignUpCommand, ModeratorSignUpResponseDTO>
    {
        private readonly IBaseRepository<ModeratorSignUpRequest> _moderatorSignUpRequestRepository = moderatorSignUpRequestRepository;
        private readonly IPasswordService _passwordService = passwordService;

        public async Task<ModeratorSignUpResponseDTO> Handle(ModeratorSignUpCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var ModeratorRequest = new ModeratorSignUpRequest
            {
                Name = request.FullName,
                Username = request.UserName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Reason = request.Reason,
            };
            ModeratorRequest = await _moderatorSignUpRequestRepository.InsertAsync(ModeratorRequest);

            return new ModeratorSignUpResponseDTO
            {
                Id = ModeratorRequest.Id.ToString(),
                FullName = ModeratorRequest.Name,
                UserName = ModeratorRequest.Username,
                Email = ModeratorRequest.Email
            };
        }
    }
}