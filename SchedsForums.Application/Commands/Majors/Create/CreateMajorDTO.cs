using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorDTO : BaseCommandReturnDTO
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string FacultyId { get; set; }
    }
}