using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommandResponseDTO : BaseIdResponseDTO
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}