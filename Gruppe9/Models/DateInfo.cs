using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    // Representerer en dato i systemet, brukt til å koble pollendata
    public class DateInfo
    {
        [Key]
        public int ID { get; set; } // Primærnøkkel i databasen

        [Required]
        public int Year { get; set; } // Årstall (f.eks. 2025)

        public int Month { get; set; } // Måned (1–12)

        public int Day { get; set; } // Dag i måneden (1–31)

        public ICollection<PollenResponse>? PollenResponses { get; set; } // Alle registreringer for denne datoen
    }
}
