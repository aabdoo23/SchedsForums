using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyDTO : BaseCommandReturnDTO
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
    }
}