using MediatR;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Users.Students.Create
{
    public class CreateStudentCommandHandler(IStudentRepository studentRepository, IHashingService passwordService) : IRequestHandler<CreateStudentCommand, BaseUserRequestBaseDTO>
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IHashingService _passwordService = passwordService;

        public async Task<BaseUserRequestBaseDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordService.HashPassword(request.Password);

            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = hashedPassword
            };
            await _studentRepository.InsertAsync(student);

            return new BaseUserRequestBaseDTO
            {
                Name = student.Name,
                UserName = student.UserName,
                Email = student.Email
            };
        }
    }
}
