
namespace SchedsForums.Domain.Entities.Common
{
    public abstract class BaseUser : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        protected BaseUser(string name, string email, string password)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseUser()
        {
        }

    }
}