using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class MajorForum : BaseForum
    {
        public Guid MajorId { get; set; }
        public virtual Major Major { get; set; }
    }
}
