using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class Student : BaseUser
    {
        public Student(string name, string email, string password) : base(name, email, password)
        {
        }
        public Student() : base() { }
        public virtual Major? Major { get; set; }
    }
}
