using SchedsForums.Interface;

namespace SchedsForums.Infrastructure.Services
{
    public class PasswordService : IBaseService
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

    }
}
