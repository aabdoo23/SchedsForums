using MediatR;

namespace SchedsForums.Application.Commands.BaseUsers.Login
{
    public class LoginCommand : IRequest<LoginResponseDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
