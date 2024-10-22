using SchedsForums.Application.Interfaces.Services;

namespace SchedsForums.Infrastructure.Services
{
    public class HashingService : IHashingService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
