using SchedsForums.Application.BaseValidators;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Moderators.Create
{
    public class CreateModeratorValidator(IBaseUserRepository baseUserRepository) : BaseCreateUserValidator<CreateModeratorCommand>(baseUserRepository)
    {
    }
}
