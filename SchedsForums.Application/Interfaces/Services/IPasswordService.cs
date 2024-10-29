using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(BaseUser user, string password);
    }
}
