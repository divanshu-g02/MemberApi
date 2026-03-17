using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MemberApi.Helper
{
    public class TokenHelper

    {

        private readonly IConfiguration _config;
        public TokenHelper(IConfiguration config)
        {
            _config = config;
        }
        public JwtSecurityToken GenerateAccessToken(string Email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Email),
            };
            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"])),
                       SecurityAlgorithms.HmacSha256)
               );
            return token;
        }
    }
}
