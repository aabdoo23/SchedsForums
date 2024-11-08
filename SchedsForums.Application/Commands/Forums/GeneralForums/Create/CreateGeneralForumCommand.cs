using MediatR;

namespace SchedsForums.Application.Commands.Forums.GeneralForums.Create
{
    public class CreateGeneralForumCommand : IRequest<CreateGeneralForumCommandResponseDTO>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<string> Guidelines { get; set; }
    }
}