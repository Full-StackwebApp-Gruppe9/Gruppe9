using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    public class PollenRegistrering
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string? TypeOfPollen { get; set; }

        [Required]
        public int Level { get; set; }
    }
}
