using SchedsForums.Application.Commands.Common;

namespace SchedsForums.Application.Commands.Admins.Create
{
    public class CreateAdminValidator : UserSignUpValidator<CreateAdminCommand, CreateAdminResponseDTO>
    {
        public CreateAdminValidator()
        {
        }
    }
}
