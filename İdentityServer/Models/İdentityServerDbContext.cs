using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace İdentityServer.Models
{
    public class İdentityServerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public İdentityServerDbContext(DbContextOptions<İdentityServerDbContext> option) : base(option) { }
    }
}
