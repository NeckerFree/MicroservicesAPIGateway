using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.DbContext
{
    public class IdentityMSContext: IdentityDbContext
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

