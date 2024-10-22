using SchedsForums.Application.Interfaces.Common;

namespace SchedsForums.Application.Interfaces.Services
{
    public interface IHashingService : IBaseService
    {
        string HashPassword(string password);
    }
}
