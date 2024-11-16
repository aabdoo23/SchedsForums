using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommandResponseDTO : BaseIdResponseDTO
    {
        public string MajorCode { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public Guid FacultyId { get; set; }
    }
}