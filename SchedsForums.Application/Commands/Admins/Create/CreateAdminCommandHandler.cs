using MediatR;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Admins.Create
{
    public class CreateAdminCommandHandler(IAdminRepository adminRepository, IHashingService passwordService) : IRequestHandler<CreateAdminCommand, BaseUserRequestBaseDTO>
    {
        private readonly IAdminRepository _adminRepository = adminRepository;
        private readonly IHashingService _passwordService = passwordService;

        public async Task<BaseUserRequestBaseDTO> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var admin = new Admin
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = hashedPassword
            };
            var created = await _adminRepository.InsertAsync(admin);

            return new BaseUserRequestBaseDTO
            {
                Name = admin.Name,
                UserName = admin.UserName,
                Email = admin.Email
            };
        }
    }
}
