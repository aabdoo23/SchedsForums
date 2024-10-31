using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Students.SignUp
{
    public class StudentSignUpCommandHandler(
        IBaseRepository<Student> studentRepository,
        IPasswordService passwordService)
        : IRequestHandler<StudentSignUpCommand, StudentSignUpResponseDTO>
    {
        private readonly IBaseRepository<Student> _studentRepository = studentRepository;
        private readonly IPasswordService _passwordService = passwordService;

        public async Task<StudentSignUpResponseDTO> Handle(StudentSignUpCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var student = new Student
            {
                Name = request.FullName,
                Email = request.Email,
                Username = request.UserName,
                PasswordHash = hashedPassword
            };
            student = await _studentRepository.InsertAsync(student);

            return new StudentSignUpResponseDTO
            {
                Id = student.Id.ToString(),
                FullName = student.Name,
                UserName = student.Username,
                Email = student.Email
            };
        }
    }
}
