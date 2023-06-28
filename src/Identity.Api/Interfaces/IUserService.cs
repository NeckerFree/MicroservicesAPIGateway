using Identity.Api.DbContext;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Interfaces
{
    public interface IUserService
    {
        (bool, string?) IsLoginValid(IdentityUser user, IdentityMSContext db);
    }
}
