using SchedsForums.Application.BaseDTOs;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentDTO : StudentDTO
    {
        public string Password { get; set; }
        public Major? Major { get; set; }
    }

}
