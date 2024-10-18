using MediatR;
using SchedsForums.Domain.Entities.Users;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public CreateStudentDTO Student { get; set; }
    }
}