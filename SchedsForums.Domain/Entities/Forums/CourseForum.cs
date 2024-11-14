using SchedsForums.Domain.Entities.Forums.Common;

namespace SchedsForums.Domain.Entities.Forums
{
    public class CourseForum : BaseForum
    {
        public virtual Course Course { get; set; }
    }
}
