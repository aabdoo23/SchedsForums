using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Moderators.SignUp
{
    public class ModeratorSignUpResponseDTO: UserResponseDTO
    {
        public string Reason { get; set; }
    }
}
