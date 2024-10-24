using FluentValidation;
using SchedsForums.Application.Commands.BaseUser;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Students.Create
{
    public class CreateStudentValidator(IBaseUserRepository baseUserRepository) : BaseCreateUserValidator<CreateStudentCommand>(baseUserRepository)
    {
    }
}
