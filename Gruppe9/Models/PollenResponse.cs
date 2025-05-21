using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models
{
    public class PollenResponse
    {
        [Key]
        public int ID { get; set; }

        // FK til DateInfo
        public int DateInfoId { get; set; }

        [ForeignKey("DateInfoId")]
        public DateInfo? DateInfo { get; set; }

        // FK til PlantInfo
        public int PlantInfoId { get; set; }

        [ForeignKey("PlantInfoId")]
        public PlantInfo? PlantInfo { get; set; }
    }
}
