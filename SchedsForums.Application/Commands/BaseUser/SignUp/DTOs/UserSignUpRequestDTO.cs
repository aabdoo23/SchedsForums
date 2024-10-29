using MediatR;

namespace SchedsForums.Application.Commands.BaseUser.SignUp.DTOs
{
    public class UserSignUpRequestDTO : IRequest<UserSignUpResponseDTO>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
