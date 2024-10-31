using MediatR;

namespace SchedsForums.Application.Commands.Admins.Create
{
    public class CreateAdminCommand : IRequest<CreateAdminResponseDTO>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
