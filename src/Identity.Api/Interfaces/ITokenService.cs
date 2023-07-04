using Identity.Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Login user, string key, string issuer, string audience);
    }
}
