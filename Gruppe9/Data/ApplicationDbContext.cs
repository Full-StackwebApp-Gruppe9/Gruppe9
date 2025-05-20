using Microsoft.EntityFrameworkCore;
using Gruppe9.Models;

namespace Gruppe9.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PollenRegistrering> PollenRegistrering { get; set; }
        public DbSet<PollenResponse> PollenResponse { get; set; }
        public DbSet<DateInfo> DateInfo { get; set; }
        public DbSet<PlantInfo> PlantInfo { get; set; }
        public DbSet<ColorInfo> ColorInfo { get; set; }
    }
}
