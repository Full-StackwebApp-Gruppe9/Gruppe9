using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    public class DateInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Dato { get; set; }

        // Navigasjon til alle responses på denne datoen
        public ICollection<PollenResponse>? PollenResponses { get; set; }
    }
}
