using SchedsForums.Application.Commands.Common.User;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpCommand : UserSignUpCommand<ModeratorSignUpResponseDTO>
    {
        public string Reason { get; set; }
    }
}
