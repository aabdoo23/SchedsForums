using MediatR;
using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Application.Commands.ForumRequests.Create
{
    public class CreateForumRequestCommand : IRequest<CreateForumRequestCommandResponseDTO>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Guidelines { get; set; }
        public string Reason { get; set; }
        public ForumType ForumType { get; set; }
    }
}
