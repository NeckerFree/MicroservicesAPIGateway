using Identity.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.DbContext
{
    public class IdentityMSContext : IdentityDbContext
    {
        public IdentityMSContext(DbContextOptions<IdentityMSContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ROLE_ID = new Guid().ToString();
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new AppUser
            {
                Id =new Guid().ToString(),
                Email = "elio@gmail.com",
                EmailConfirmed = true,
                FirstName = "Elio",
                LastName = "Cortés",
                UserName = "elio@gmail.com",
                NormalizedUserName = "ELIO@GMAIL.COM"
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "sa_elio$");

            //seed user
            builder.Entity<AppUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = appUser.Id,
            });
        }
    }
}
    
        
