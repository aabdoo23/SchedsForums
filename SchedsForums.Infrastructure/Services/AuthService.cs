using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
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
