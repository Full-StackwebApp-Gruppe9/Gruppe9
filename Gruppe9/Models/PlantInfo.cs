using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models
{
    // Representerer en plante som måles i pollensystemet
    public class PlantInfo
    {
        [Key]
        public int ID { get; set; } // Primærnøkkel i databasen

        [Required]
        public string? PlanteType { get; set; } // Navn/type på planten

        public int ColorInfoId { get; set; } // Fremmednøkkel til tilknyttet farge

        [ForeignKey("ColorInfoId")]
        public ColorInfo? ColorInfo { get; set; } // Navigasjon til fargeinformasjon

        public ICollection<PollenResponse>? PollenResponses { get; set; } // Alle pollenregistreringer knyttet til planten
    }
}
