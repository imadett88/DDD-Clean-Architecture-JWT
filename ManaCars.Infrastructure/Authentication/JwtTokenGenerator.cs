using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography; // Added for key generation
using System.Text;
using ManaCars.Application.Common.Interfaces.Authentication;
using ManaCars.Application.Common.Interfaces.Services;
using ManaCars.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ManaCars.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {


            //         var signingCredentials = new SigningCredentials(
            // new SymmetricSecurityKey(
            //     Encoding.UTF8.GetBytes("super-srcret-key")),
            // SecurityAlgorithms.HmacSha256);

            // fix with this :
            var key = new byte[32]; // 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                 SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
