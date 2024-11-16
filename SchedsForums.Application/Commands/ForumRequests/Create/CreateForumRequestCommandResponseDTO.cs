using SchedsForums.Application.Interfaces.Common.DTOs;
using SchedsForums.Domain.Entities.Forums.Common;
using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Commands.ForumRequests.Create
{
    public class CreateForumRequestCommandResponseDTO : BaseIdResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Guidelines { get; set; }
        public string Reason { get; set; }
        public ForumType ForumType { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}