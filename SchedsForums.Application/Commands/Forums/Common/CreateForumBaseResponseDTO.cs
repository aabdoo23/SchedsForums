using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Commands.Forums.Common
{
    public abstract class CreateForumBaseResponseDTO : BaseIdResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<string> Guidelines { get; set; }
        public Guid CreatedById { get; set; }
    }
}