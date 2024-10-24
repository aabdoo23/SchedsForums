using MediatR;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommandHandler(IFacultyRepository facultyRepository) : IRequestHandler<CreateFacultyCommand, CreateFacultyDTO>
    {
        private readonly IFacultyRepository _facultyRepository = facultyRepository ?? throw new ArgumentNullException(nameof(facultyRepository));

        public async Task<CreateFacultyDTO> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = new Faculty
            {
                ShortName = request.ShortName,
                FullName = request.FullName
            };

            var created = await _facultyRepository.InsertAsync(faculty);

            return new CreateFacultyDTO
            {
                Id = created.Id,
                ShortName = created.ShortName,
                FullName = created.FullName,
            };
        }
    }
}
