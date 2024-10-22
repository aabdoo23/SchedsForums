using MediatR;
using SchedsForums.Application.Commands.Students.Login.DTOs;

namespace SchedsForums.Application.Commands.Students.Login
{
    public class LoginCommand : IRequest<LoginResponseDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
