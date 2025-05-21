using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models
{
    public class PlantInfo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? PlanteType { get; set; }

        // FK til ColorInfo
        public int ColorInfoId { get; set; }

        [ForeignKey("ColorInfoId")]
        public ColorInfo? ColorInfo { get; set; }

        // Navigasjon til alle responses for denne planten
        public ICollection<PollenResponse>? PollenResponses { get; set; }
    }
}
