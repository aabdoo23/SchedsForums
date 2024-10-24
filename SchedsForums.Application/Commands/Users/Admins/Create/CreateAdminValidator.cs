using SchedsForums.Application.BaseValidators;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Users.Admins.Create
{
    public class CreateAdminValidator(IBaseUserRepository baseUserRepository) : BaseCreateUserValidator<CreateAdminCommand>(baseUserRepository)
    {
    }
}
