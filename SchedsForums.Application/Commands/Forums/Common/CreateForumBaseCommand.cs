using MediatR;

namespace SchedsForums.Application.Commands.Forums.Common
{
    public abstract class CreateForumBaseCommand<T> : IRequest<T> where T : CreateForumBaseResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<string> Guidelines { get; set; }
    }
}
