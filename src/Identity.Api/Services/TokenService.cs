using Identity.Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Api.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(IdentityUser user, string secretKey, string issuer, string audience)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
                      var descriptor = new SecurityTokenDescriptor
                    {
                        Issuer = issuer,
                        Audience = audience,
                        //Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim(ClaimTypes.Role, user.Roles) }),
                        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString())}),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
            var token = handler.CreateToken(descriptor);
            //var descriptor = new SecurityTokenDescriptor();
            //var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
