using SchedsForums.Application.Interfaces.Common.DTOs;

namespace SchedsForums.Application.Commands.Common
{
    public class UserResponseDTO : BaseIdResponseDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
