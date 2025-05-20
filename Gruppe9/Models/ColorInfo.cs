using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    public class ColorInfo
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 255)]
        public int Red { get; set; }

        [Range(0, 255)]
        public int Green { get; set; }

        [Range(0, 255)]
        public int Blue { get; set; }
    }
}
