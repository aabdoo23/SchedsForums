using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class MajorForum : BaseForum
    {
        public string MajorId { get; set; }
        public virtual Major? Major { get; set; }
    }
}
