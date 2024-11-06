using SchedsForums.Application.Commands.Common.User;

namespace SchedsForums.Application.Commands.Students.SignUp
{
    public class StudentSignUpValidator : UserSignUpValidator<StudentSignUpCommand, StudentSignUpResponseDTO>
    {
        public StudentSignUpValidator()
        {
        }
    }
}
