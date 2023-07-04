using Identity.Api.DbContext;
using Identity.Api.Entities;
using Identity.Api.Interfaces;

namespace Identity.Api.Services
{
    public class UserService : IUserService
    {

        public (bool, string?) IsLoginValid(Login login, IdentityMSContext db)
        {
            var dbUser = db.Users.FirstOrDefault(u => u.Email == login.Email);
            if (dbUser == null)
            {
                return (false, null);
            }

            return (true, dbUser.UserName);
        }
        
    }
}
