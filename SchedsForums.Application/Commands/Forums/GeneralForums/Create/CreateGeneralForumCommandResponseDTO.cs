using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommandResponseDTO : BaseResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<string> Guidelines { get; set; }
        public Guid CreatedById { get; set; }
    }
}