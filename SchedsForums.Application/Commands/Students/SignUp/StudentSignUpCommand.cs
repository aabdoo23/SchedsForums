using MediatR;

namespace SchedsForums.Application.Commands.Students.SignUp
{
    public class StudentSignUpCommand : IRequest<StudentSignUpResponseDTO>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
