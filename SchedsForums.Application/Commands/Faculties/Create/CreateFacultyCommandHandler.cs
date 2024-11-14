using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Faculties.Create
{
    public class CreateFacultyCommandHandler(IBaseRepository<Faculty> facultyRepository) : IRequestHandler<CreateFacultyCommand, CreateFacultyCommandResponseDTO>
    {
        private readonly IBaseRepository<Faculty> _facultyRepository = facultyRepository
            ?? throw new ArgumentNullException(nameof(facultyRepository));
        public async Task<CreateFacultyCommandResponseDTO> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = new Faculty
            {
                ShortName = request.ShortName,
                FullName = request.FullName,
                Description = request.Description
            };

            await _facultyRepository.InsertAsync(faculty);
            
            return new CreateFacultyCommandResponseDTO
            {
                Id = faculty.Id,
                ShortName = faculty.ShortName,
                FullName = faculty.FullName,
                Description = faculty.Description
            };
        }
    }
}
