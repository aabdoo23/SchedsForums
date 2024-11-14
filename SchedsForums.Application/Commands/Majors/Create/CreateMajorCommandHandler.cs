using MediatR;
using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorCommandHandler(IBaseRepository<Major> majorRepository) : IRequestHandler<CreateMajorCommand, CreateMajorCommandResponseDTO>
    {
        private readonly IBaseRepository<Major> _majorRepository = majorRepository
                ?? throw new ArgumentNullException(nameof(majorRepository));
        public async Task<CreateMajorCommandResponseDTO> Handle(CreateMajorCommand request, CancellationToken cancellationToken)
        {
            var major = new Major
            {
                ShortName = request.MajorCode,
                FullName = request.MajorName,
                Description = request.Description,
                FacultyId = request.FacultyId
            };
            await _majorRepository.InsertAsync(major);
            return new CreateMajorCommandResponseDTO
            {
                Id = major.Id,
                MajorCode = major.ShortName,
                MajorName = major.FullName,
                Description = major.Description,
                FacultyId = major.FacultyId
            };
        }
    }
}
