using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BP_TPWA.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uzivatel>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<BP_TPWA.Models.TP> TP { get; set; } = default!;
        public DbSet<BP_TPWA.Models.DenVTydnu> DenVTydnu { get; set; }
        public DbSet<BP_TPWA.Models.DenTreninku> DenTreninku { get; set; }
        public DbSet<BP_TPWA.Models.Cvik> Cvik { get; set; } = default!;
        public DbSet<BP_TPWA.Models.TreninkoveData> TreninkoveData { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TP>()
                .HasMany(tp => tp.DnyVTydnu)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
