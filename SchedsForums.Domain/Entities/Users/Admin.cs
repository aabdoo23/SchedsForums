using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Domain.Entities.Users
{
    public class Admin : BaseUser
    {
        public Admin(string name, string email, string password) : base(name, email, password)
        {
        }
        protected Admin() : base()
        {
        }
    }
}
