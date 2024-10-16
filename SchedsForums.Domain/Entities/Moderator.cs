using SchedsForums.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedsForums.Domain.Entities
{
    public class Moderator : BaseUser
    {
        public Moderator(string name, string email, string password) : base(name, email, password)
        {
        }
    }
}
