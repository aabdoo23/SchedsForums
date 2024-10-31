using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Students.SignUp
{
    public class StudentSignUpValidator : UserSignUpValidator<StudentSignUpCommand, StudentSignUpResponseDTO>
    {
        public StudentSignUpValidator()
        {
        }
    }
}
