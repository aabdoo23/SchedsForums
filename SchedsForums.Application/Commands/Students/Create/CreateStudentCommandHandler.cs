using FluentValidation;
using MediatR;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommandHandler(IStudentRepository studentRepository, IHashingService passwordService, IValidator<CreateStudentCommand> validator) : IRequestHandler<CreateStudentCommand, StudentRequestBaseDTO>
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IHashingService _passwordService = passwordService;
        private readonly IValidator<CreateStudentCommand> _validator = validator;

        public async Task<StudentRequestBaseDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request,cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var hashedPassword = _passwordService.HashPassword(request.Password);

            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = hashedPassword
            };
            await _studentRepository.InsertAsync(student);

            return new StudentRequestBaseDTO
            {
                Name = student.Name,
                UserName = student.UserName,
                Email = student.Email
            };
        }
    }
}
