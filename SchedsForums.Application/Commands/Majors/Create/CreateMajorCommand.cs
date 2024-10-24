using MediatR;

namespace SchedsForums.Application.Commands.Majors.Create
{
	public class CreateMajorCommand : IRequest<CreateMajorDTO>
	{
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string FacultyId { get; set; }
    }
}
