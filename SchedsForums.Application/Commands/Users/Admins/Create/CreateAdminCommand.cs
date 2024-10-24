using MediatR;
using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Users.Admins.Create
{
    public class CreateAdminCommand : BaseCreateUserCommand, IRequest<BaseUserRequestBaseDTO> //keeping this for the future to add more data on sign up
    {
    }
}
