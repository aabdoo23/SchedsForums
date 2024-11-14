using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.MajorForums.Create
{
    public class CreateMajorForumCommand : CreateForumBaseCommand<CreateMajorForumCommandResponseDTO>
    {
        public Guid MajorId { get; set; }
    }
}
