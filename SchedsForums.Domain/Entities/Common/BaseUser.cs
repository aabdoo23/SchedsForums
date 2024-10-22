namespace SchedsForums.Domain.Entities.Common
{
    public abstract class BaseUser : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}