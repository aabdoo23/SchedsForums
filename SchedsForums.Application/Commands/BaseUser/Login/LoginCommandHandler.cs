using MediatR;
using SchedsForums.Application.Commands.BaseUser.Login.DTOs;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;

namespace SchedsForums.Application.Commands.BaseUser.Login
{
    public class LoginCommandHandler(IBaseUserRepository userRepository, IAuthService authService, IJWTService jwtService) : IRequestHandler<LoginRequestDTO, LoginResponseDTO>
    {
        private readonly IBaseUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        private readonly IJWTService _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        private readonly IAuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        public async Task<LoginResponseDTO> Handle(LoginRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBaseUserByUserNameAsync(request.Username);

            _authService.VerifyPassword(user, request.Password);

            var token = _jwtService.GenerateToken(user);
            return new LoginResponseDTO { Token = token };
        }
    }
}
