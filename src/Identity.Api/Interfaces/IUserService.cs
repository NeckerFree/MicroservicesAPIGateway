using Identity.Api.DbContext;
using Identity.Api.Entities;

namespace Identity.Api.Interfaces
{
    public interface IUserService
    {
        (bool, string?) IsLoginValid(Login login, IdentityMSContext db);
    }
}
