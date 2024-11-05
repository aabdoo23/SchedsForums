namespace SchedsForums.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        public Guid GetUserId();
        public string GetUsername();
        public string GetUserRole();
        public bool IsAuthenticated();
    }
}
