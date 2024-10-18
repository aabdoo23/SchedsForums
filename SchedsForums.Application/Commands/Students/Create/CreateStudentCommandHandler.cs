using MediatR;
using SchedsForums.Domain.Entities.Users;
using SchedsForums.Domain.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Student.Name, request.Student.Email, request.Student.Password);
            student.Major = request.Student.Major;
            await _studentRepository.InsertAsync(student);
            return student;

        }
    }
}
