using MediatR;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommand : IRequest<CreateMajorCommandResponseDTO>
    {
        public string MajorCode { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public Guid FacultyId { get; set; }
    }
}
