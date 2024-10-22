using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Services
{
    public interface IAuthService
    {
        bool VerifyPassword(BaseUser user, string password);
        string GenerateToken(BaseUser user);
    }
}
