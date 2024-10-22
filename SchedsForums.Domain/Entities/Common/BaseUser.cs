namespace SchedsForums.Domain.Entities.Common
{
    public abstract class BaseUser : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}