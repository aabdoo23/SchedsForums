using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities
{
    public class ModeratorSignUpRequest : AuditableEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }
}
