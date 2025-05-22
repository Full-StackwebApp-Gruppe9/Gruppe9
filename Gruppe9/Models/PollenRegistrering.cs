using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    // Representerer en manuell registrering av pollennivå
    public class PollenRegistrering
    {
        [Key]
        public int ID { get; set; } // Primærnøkkel i databasen

        [Required]
        public DateTime Date { get; set; } // Dato for registreringen

        [Required]
        [StringLength(50)]
        public string? TypeOfPollen { get; set; } // Type pollen (maks 50 tegn)

        [Required]
        public int Level { get; set; } // Målt pollennivå
    }
}
