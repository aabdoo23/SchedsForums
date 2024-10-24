using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class CourseForum : BaseForum
    {
        public virtual Course? Course { get; set; }
    }
}
