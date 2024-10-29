using MediatR;

namespace SchedsForums.Application.Commands.BaseUser.Login.DTOs
{
    public class LoginRequestDTO : IRequest<LoginResponseDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
