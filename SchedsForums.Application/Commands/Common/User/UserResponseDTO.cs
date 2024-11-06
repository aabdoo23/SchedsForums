namespace SchedsForums.Application.Commands.Common.User
{
    public class UserResponseDTO : BaseResponseDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
