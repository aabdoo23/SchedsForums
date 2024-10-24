using MediatR;
using SchedsForums.Application.BaseDTOs;

namespace SchedsForums.Application.Commands.Users.Moderators.Create
{
    public class CreateModeratorCommand : BaseCreateUserCommand, IRequest<BaseUserRequestBaseDTO> //keeping this for the future to add more data on sign up
    {
    }
}
