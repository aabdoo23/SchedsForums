using MediatR;
using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommand : IRequest<StudentDTO>
    {
        public CreateStudentDTO Student { get; set; }
    }
}