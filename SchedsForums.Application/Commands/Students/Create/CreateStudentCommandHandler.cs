using FluentValidation;
using MediatR;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Services.Interfaces;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDTO>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPasswordService _passwordService;
        private readonly IValidator<CreateStudentDTO> _validator = new CreateStudentValidator();

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IPasswordService passwordService)
        {
            _studentRepository = studentRepository;
            _passwordService = passwordService;
        }

        public async Task<StudentDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Student);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var hashedPassword = _passwordService.HashPassword(request.Student.Password);

            var student = new Student
            {
                Name = request.Student.Name,
                Email = request.Student.Email,
                Password = hashedPassword,
                Major = request.Student.Major
            };

            await _studentRepository.InsertAsync(student);

            return new StudentDTO
            {
                Name = student.Name,
                Email = student.Email
            };
        }
    }

}
