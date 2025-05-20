using System;
using System.ComponentModel.DataAnnotations;

namespace Gruppe9.Models

{
    public class DateInfo
    {
        public int id { get; set; }

        [Required]
        public int year { get; set; }

        [Required]
        public int month { get; set; }
        
        [Required]
        public int day { get; set; }
        
        
    }
}