using FluentValidation;
using SchedsForums.Application.BaseValidators;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Users.Students.Create
{
    public class CreateStudentValidator(IBaseUserRepository baseUserRepository) : BaseCreateUserValidator<CreateStudentCommand>(baseUserRepository)
    {
    }
}
