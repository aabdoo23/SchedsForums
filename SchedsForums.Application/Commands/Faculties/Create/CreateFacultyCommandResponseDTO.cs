using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommandResponseDTO : BaseResponseDTO
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}