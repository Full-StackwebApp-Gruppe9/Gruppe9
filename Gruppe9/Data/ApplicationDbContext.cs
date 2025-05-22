using Microsoft.EntityFrameworkCore;
using Gruppe9.Models;

namespace Gruppe9.Data
{
    // Databasekontekst for hele applikasjonen
    // Definerer hvilke modeller (tabeller) som skal spores og lagres av Entity Framework
    public class ApplicationDbContext : DbContext
    {
        // Konstruktør som mottar konfigurasjonsalternativer (typisk fra Program.cs)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for pollenregistreringer som er manuelt lagt inn
        public DbSet<PollenRegistrering> PollenRegistrering { get; set; }

        // DbSet for kobling mellom dato og plante, som representerer rådata fra API
        public DbSet<PollenResponse> PollenResponse { get; set; }

        // DbSet for datoobjekter (en dato per dag med polleninfo)
        public DbSet<DateInfo> DateInfo { get; set; }

        // DbSet for planteinformasjon som hører til pollenrespons
        public DbSet<PlantInfo> PlantInfo { get; set; }

        // DbSet for fargeinformasjon brukt til visuell fremstilling av nivå
        public DbSet<ColorInfo> ColorInfo { get; set; }

        // DbSet for pollenindeksdata, som inneholder nivå, kategori, beskrivelse og farge
        public DbSet<IndexInfo> IndexInfo { get; set; }
    }
}