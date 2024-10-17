using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class Moderator : BaseUser
    {
        public Moderator(string name, string email, string password) : base(name, email, password)
        {
        }
        public Moderator() : base()
        {
        }
    }
}
