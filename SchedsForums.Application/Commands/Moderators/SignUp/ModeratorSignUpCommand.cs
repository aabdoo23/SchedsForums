using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpCommand : UserSignUpCommand<ModeratorSignUpResponseDTO>
    {
        public string Reason { get; set; }
    }
}
