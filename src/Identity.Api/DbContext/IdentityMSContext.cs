using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Identity.Api.DbContext
{
    public class IdentityMSContext: IdentityUserContext<IdentityUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public IdentityMSContext(DbContextOptions<IdentityMSContext> options)
            :base(options)
        {
                
        }
    }
}

