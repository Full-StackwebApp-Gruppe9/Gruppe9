using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    // Representerer en RGB-farge brukt for visuell pollenindikasjon
    public class ColorInfo
    {
        [Key]
        public int ID { get; set; } // Primærnøkkel i databasen

        [Range(0, 255)]
        public int Red { get; set; } // Rød kanal (0–255)

        [Range(0, 255)]
        public int Green { get; set; } // Grønn kanal (0–255)

        [Range(0, 255)]
        public int Blue { get; set; } // Blå kanal (0–255)
    }
}
