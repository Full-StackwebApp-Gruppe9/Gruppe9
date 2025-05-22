using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models
{
    // Representerer koblingen mellom en plante og en dato i en pollenregistrering
    public class PollenResponse
    {
        [Key]
        public int ID { get; set; } // Primærnøkkel i databasen

        public int DateInfoId { get; set; } // Fremmednøkkel til dato

        [ForeignKey("DateInfoId")]
        public DateInfo? DateInfo { get; set; } // Navigasjon til datoobjekt

        public int PlantInfoId { get; set; } // Fremmednøkkel til plante

        [ForeignKey("PlantInfoId")]
        public PlantInfo? PlantInfo { get; set; } // Navigasjon til planteobjekt
    }
}
