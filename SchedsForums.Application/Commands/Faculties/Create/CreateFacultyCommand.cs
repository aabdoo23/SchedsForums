using MediatR;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommand : IRequest<CreateFacultyCommandResponseDTO>
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
