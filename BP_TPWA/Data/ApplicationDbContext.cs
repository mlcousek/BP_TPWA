using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Models;

namespace BP_TPWA.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uzivatel>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BP_TPWA.Models.TP> TP { get; set; } = default!;
        public DbSet<BP_TPWA.Models.DenVTydnu> DenVTydnu { get; set; }

    }
}
