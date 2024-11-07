using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommandResponseDTO : BaseResponseDTO
    {
        public string MajorCode { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public Guid FacultyId { get; set; }
    }
}