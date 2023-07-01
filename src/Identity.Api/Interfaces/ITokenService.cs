using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser user, string key, string issuer, string audience);
    }
}
