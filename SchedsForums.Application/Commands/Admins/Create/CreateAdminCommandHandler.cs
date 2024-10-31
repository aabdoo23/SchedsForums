using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Admins.Create
{
    public class CreateAdminCommandHandler(
        IBaseRepository<Admin> adminRepository,
        IPasswordService passwordService) : IRequestHandler<CreateAdminCommand,CreateAdminResponseDTO>
    {
        private readonly IBaseRepository<Admin> _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        private readonly IPasswordService _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));

        public async Task<CreateAdminResponseDTO> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var admin = new Admin
            {
                Name = request.FullName,
                Email = request.Email,
                Username = request.UserName,
                PasswordHash = hashedPassword
            };
            admin = await _adminRepository.InsertAsync(admin);

            return new CreateAdminResponseDTO
            {
                Id = admin.Id.ToString(),
                FullName = admin.Name,
                UserName = admin.Username,
                Email = admin.Email
            };
        }
    }
}
