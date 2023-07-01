using Identity.Api.DbContext;
using Identity.Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Identity.Api.DTOs.DTOs;

namespace Identity.Api.Services
{
    public class UserService : IUserService
    {

        public (bool, string?) IsLoginValid(IdentityUser user, IdentityMSContext db)
        {
            Hasher.PasswordHasher<UserDto> passwordHasher = new Hasher.PasswordHasher<UserDto>();
            var dbUser = db.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            return (dbUser != null, dbUser.Result.UserName);
        }
    }
}
