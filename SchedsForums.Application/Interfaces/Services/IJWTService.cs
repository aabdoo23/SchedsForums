using SchedsForums.Domain.Entities.Users.Common;

namespace SchedsForums.Application.Interfaces.Services
{
    public interface IJWTService
    {
        string GenerateToken(BaseUser user);
    }
}
