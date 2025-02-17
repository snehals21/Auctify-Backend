using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Common
{

    public class AuthConfigService
    {
        private readonly string? _jwtkey;
        private readonly int _jwtExpiry;

        public AuthConfigService(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IConfiguration configuration)
        {
            _jwtkey = configuration["Jwt:Key"];
            _jwtExpiry = 60;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", user.FullName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtkey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddMinutes(_jwtExpiry),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
