using MediatR;
using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentCommand : StudentRequestBaseDTO, IRequest<StudentRequestBaseDTO>
    {
        public string Password { get; set; }
    }
}