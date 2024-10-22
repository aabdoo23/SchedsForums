using MediatR;
using SchedsForums.Application.Commands.Students.Login.DTOs;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;

namespace SchedsForums.Application.Commands.Students.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
    {
        private readonly IBaseUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IBaseUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBaseUserByUserNameAsync(request.Username);

            if (user == null || !_authService.VerifyPassword(user, request.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = _authService.GenerateToken(user);
            return new LoginResponseDTO { Token = token };
        }
    }
}
