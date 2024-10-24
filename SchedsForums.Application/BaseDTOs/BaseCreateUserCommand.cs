namespace SchedsForums.Application.BaseDTOs
{
    public class BaseCreateUserCommand : BaseUserRequestBaseDTO
    {
        public string Password { get; set; }
    }
}
