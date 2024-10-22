using SchedsForums.Domain.Interfaces;
namespace SchedsForums.Infrastructure.Services.Interfaces
{
    public interface IHashingService : IBaseService
    {
        string HashPassword(string password);
    }
}
