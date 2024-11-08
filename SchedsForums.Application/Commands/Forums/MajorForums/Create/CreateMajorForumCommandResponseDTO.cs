using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.MajorForums.Create
{
    public class CreateMajorForumCommandResponseDTO : CreateForumBaseResponseDTO
    {
        public Guid MajorId { get; set; }
    }
}