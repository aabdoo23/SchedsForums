using MediatR;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;

namespace SchedsForums.Application.Commands.BaseUsers.Login
{
    public class LoginCommandHandler(
        IBaseUserRepository userRepository,
        IPasswordService passwordService,
        IJWTService jwtService) : IRequestHandler<LoginCommand, LoginResponseDTO>
    {
        private readonly IBaseUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        private readonly IJWTService _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        private readonly IPasswordService _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));

        public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBaseUserByUserNameAsync(request.Username);

            _passwordService.VerifyPassword(user, request.Password);

            var token = _jwtService.GenerateToken(user);
            return new LoginResponseDTO { Token = token };
        }
    }
}
