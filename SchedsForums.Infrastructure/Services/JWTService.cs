using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchedsForums.Application.Interfaces.Services;
using SchedsForums.Domain.Entities.Common;
using SchedsForums.Infrastructure.ConfigurationOptions;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchedsForums.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SymmetricSecurityKey _securityKey;

        public JWTService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value ?? throw new DataException("Can't find JWT Options in App Settings.");
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)) ?? throw new DataException("Can't find JWT Key in App Settings.");
        }

        public string GenerateToken(BaseUser user)
        {
            var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            var role = user.GetType().Name;
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
