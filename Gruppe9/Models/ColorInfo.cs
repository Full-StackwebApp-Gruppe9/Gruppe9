using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gruppe9.Models;

public class ColorInfo
{
    public int ID { get; set; } //Primary Key
    [Required]
    public float Red { get; set; }
    public float Green { get; set; }
    public float Blue { get; set; }
}
