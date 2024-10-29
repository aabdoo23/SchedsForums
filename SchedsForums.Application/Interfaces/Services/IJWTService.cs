using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Services
{
    public interface IJWTService
    {
        string GenerateToken(BaseUser user);
    }
}
