using MediatR;
using SchedsForums.Application.Interfaces.Repositories;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommandHandler(IMajorRepository majorRepository) : IRequestHandler<CreateMajorCommand, CreateMajorDTO>
    {
        private readonly IMajorRepository _majorRepository = majorRepository ?? throw new ArgumentNullException(nameof(majorRepository));

        public async Task<CreateMajorDTO> Handle(CreateMajorCommand request, CancellationToken cancellationToken)
        {
            var major = new Major
            {
                ShortName = request.ShortName,
                FullName = request.FullName,
                FacultyId = request.FacultyId
            };
            var created = await _majorRepository.InsertAsync(major);

            return new CreateMajorDTO
            {
                ShortName = created.ShortName,
                FullName = created.FullName,
                FacultyId = created.FacultyId,
                Id = created.Id
            };
        }
    }
}
