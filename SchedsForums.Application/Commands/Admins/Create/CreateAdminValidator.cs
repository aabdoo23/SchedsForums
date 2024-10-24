using SchedsForums.Application.Commands.BaseUser;
using SchedsForums.Application.Commands.Students.Create;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Admins.Create
{
    public class CreateAdminValidator(IBaseUserRepository baseUserRepository) : BaseCreateUserValidator<CreateStudentCommand>(baseUserRepository)
    {
    }
}
