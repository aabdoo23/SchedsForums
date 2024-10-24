using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchedsForums.Infrastructure.Services
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        private readonly IConfiguration _config = configuration;

        public string GenerateToken(BaseUser user)
        {
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new NullReferenceException("Can't find JWT Key in Env Variables.");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = user.GetType().Name;
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerifyPassword(BaseUser user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
