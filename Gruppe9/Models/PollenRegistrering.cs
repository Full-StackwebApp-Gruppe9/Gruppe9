using System;
using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models
{
    public class PollenRegistrering
    {

        // Primær nøkkel
        public int ID { get; set; }

        //Dato må være required siden det er snakk om registrering
        [Required]
        public DateTime date { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Type of pollen can be at most 50 characters long.")]
        public String? TypeOfPollen { get; set; }

        [Required]
        public int? Level { get; set; }

        

    }
}