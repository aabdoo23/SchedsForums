using SchedsForums.Domain.Interfaces;

namespace SchedsForums.Infrastructure.Services.Interfaces
{
    public interface IPasswordService : IBaseService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
