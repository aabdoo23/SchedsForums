using Microsoft.AspNetCore.Http;
using SchedsForums.Application.Interfaces.Services;
using System.Security.Claims;

namespace SchedsForums.Infrastructure.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public Guid GetUserId()
        {
            var userId = GetClaimValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userId);
        }

        public string GetUsername()
        {
            return GetClaimValue(ClaimTypes.Name)
                ?? throw new InvalidOperationException("Username claim not found");
        }

        public string GetUserRole()
        {
            return GetClaimValue(ClaimTypes.Role)
                ?? throw new InvalidOperationException("User role claim not found");
        }

        private string? GetClaimValue(string claimType)
        {
            return _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
