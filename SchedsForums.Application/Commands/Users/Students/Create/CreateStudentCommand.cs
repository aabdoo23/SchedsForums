using MediatR;
using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Users.Students.Create
{
    public class CreateStudentCommand : BaseCreateUserCommand, IRequest<BaseUserRequestBaseDTO> //keeping this for the future to add more data on sign up
    {
    }
}