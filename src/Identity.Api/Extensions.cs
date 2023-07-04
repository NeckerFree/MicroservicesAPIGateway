using Identity.Api.Entities;
using static Identity.Api.DTOs.DTOs;

namespace Identity.Api
{
    public static class Extensions
    {
        public static AppUser ToAppUser(this UserDto user)
        {
            AppUser appUser = new AppUser()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };
            return appUser;
        }

    }
}
