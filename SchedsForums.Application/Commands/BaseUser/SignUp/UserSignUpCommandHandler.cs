using MediatR;
using SchedsForums.Application.Commands.BaseUser.SignUp.DTOs;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.BaseUser.SignUp
{
    public class UserSignUpCommandHandler(
        IBaseRepository<Student> studentRepository,
        IHashingService passwordService)
        : IRequestHandler<UserSignUpRequestDTO, UserSignUpResponseDTO>
    {
        private readonly IBaseRepository<Student> _studentRepository = studentRepository;
        private readonly IHashingService _passwordService = passwordService;

        public async Task<UserSignUpResponseDTO> Handle(UserSignUpRequestDTO request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var student = new Student
            {
                Name = request.FullName,
                Email = request.Email,
                Username = request.UserName,
                PasswordHash = hashedPassword
            };
            await _studentRepository.InsertAsync(student);

            return new UserSignUpResponseDTO
            {
                FullName = student.Name,
                UserName = student.Username,
                Email = student.Email
            };
        }
    }
}
