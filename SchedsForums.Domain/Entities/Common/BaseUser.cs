using SchedsForums.Infrastructure.Services;
using SchedsForums.Interface;

namespace SchedsForums.Domain.Entities.Common
{
    public abstract class BaseUser : BaseEntity
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public string Name { get; set; }
        public string Email { get; set; }

        private string _password;
        public string Password => _password;
        protected BaseUser(string name, string email, string password)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            _password = PasswordService.HashPassword(password);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
