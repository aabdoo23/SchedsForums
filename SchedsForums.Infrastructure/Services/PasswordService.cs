using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(BaseUser user, string password)
        {
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return true;
        }
    }
}
