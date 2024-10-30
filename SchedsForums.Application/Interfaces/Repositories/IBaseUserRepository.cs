using SchedsForums.Application.Interfaces.Common;
using SchedsForums.Domain.Entities.Common;

namespace SchedsForums.Application.Interfaces.Repositories
{
    public interface IBaseUserRepository : IBaseRepository<BaseUser>
    {
        Task<BaseUser> GetBaseUserByEmailAsync(string email);
        Task<BaseUser> GetBaseUserByUserNameAsync(string userName);
    }
}
