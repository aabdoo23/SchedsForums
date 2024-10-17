using SchedsForums.Domain.Entities.Common;
using SchedsForums.Infrastructure.Services;

public abstract class BaseUser : BaseEntity
{
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
    protected BaseUser()
    {
    }

    public void SetPassword(string password)
    {
        _password = PasswordService.HashPassword(password);
        UpdatedAt = DateTime.UtcNow;
    }
}
