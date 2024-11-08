using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.FacultyForums.Create
{
    public class CreateFacultyForumCommand : CreateForumBaseCommand<CreateFacultyForumCommandResponseDTO>
    {
        public Guid FacultyId { get; set; }
    }
}
