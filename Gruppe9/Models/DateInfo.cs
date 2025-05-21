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
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        // Navigasjon til alle responses på denne datoen
        public ICollection<PollenResponse>? PollenResponses { get; set; }
    }
}
