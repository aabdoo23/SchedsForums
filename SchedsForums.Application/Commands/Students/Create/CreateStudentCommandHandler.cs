using FluentValidation;
using MediatR;
using SchedsForums.Application.BaseDTOs;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;
using SchedsForums.Infrastructure.Services.Interfaces;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentRequestBaseDTO>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IHashingService _passwordService;
        private readonly IValidator<CreateStudentCommand> _validator;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IHashingService passwordService, IValidator<CreateStudentCommand> validator)
        {
            _studentRepository = studentRepository;
            _passwordService = passwordService;
            _validator = validator;
        }

        public async Task<StudentRequestBaseDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var hashedPassword = _passwordService.HashPassword(request.Password);

            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword
            };

            await _studentRepository.InsertAsync(student);

            return new StudentRequestBaseDTO
            {
                Name = student.Name,
                Email = student.Email
            };
        }
    }

}
