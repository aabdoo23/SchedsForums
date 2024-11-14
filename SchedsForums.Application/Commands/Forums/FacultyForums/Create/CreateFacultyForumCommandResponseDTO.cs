using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.FacultyForums.Create
{
    public class CreateFacultyForumCommandResponseDTO : CreateForumBaseResponseDTO
    {
        public Guid FacultyId { get; set; }
    }
}